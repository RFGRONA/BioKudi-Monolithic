using BioKudi.dto;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;

namespace BioKudi.Repository
{
    public class PictureRepository
    {
        private readonly BiokudiDbContext _context;
        public PictureRepository(BiokudiDbContext context)
        {
            _context = context;
        }

        public PictureDto Create(PictureDto picture)
        {
            var pictureEntity = new Picture
            {
                Name = picture.Name,
                Link = picture.Link
            };

            _context.Pictures.Add(pictureEntity);
            _context.SaveChanges();
            picture.IdPicture = pictureEntity.IdPicture;

            foreach (var placeId in picture.Places)
            {
                var placeEntity = _context.Places.Find(placeId);
                if (placeEntity != null)
                {
                    _context.Entry(pictureEntity).Collection(p => p.IdPlaces).Load();
                    pictureEntity.IdPlaces.Add(placeEntity);
                }
            }
            _context.SaveChanges();
            return picture;
        }

        public PictureDto GetPicture(int id)
        {
            var pictureEntity = _context.Pictures.Include(p => p.IdPlaces).FirstOrDefault(p => p.IdPicture == id);
            if (pictureEntity == null)
                return null;
            var picture = new PictureDto
            {
                IdPicture = pictureEntity.IdPicture,
                Name = pictureEntity.Name,
                Link = pictureEntity.Link
            };
            var places = pictureEntity.IdPlaces;
            foreach (var placeEntity in places)
            {
                var placeDto = new PlaceDto
                {
                    IdPlace = placeEntity.IdPlace,
                    NamePlace = placeEntity.NamePlace
                };
                picture.PlacesData.Add(placeDto);
            }
            if (picture.PlacesData == null)
            {
                picture.PlacesData = new List<PlaceDto>();
            }
            return picture;
        }


        public List<PictureDto> GetListPicture()
        {
            var pictureEntities = _context.Pictures.Include(p => p.IdPlaces);
            var pictures = new List<PictureDto>();
            foreach (var pictureEntity in pictureEntities)
            {
                var picture = new PictureDto
                {
                    IdPicture = pictureEntity.IdPicture,
                    Name = pictureEntity.Name,
                    Link = pictureEntity.Link,
                    Places = pictureEntity.IdPlaces.Select(p => p.IdPlace).ToList()
                };
                pictures.Add(picture);
            }
            return pictures;
        }

        public PictureDto Update(PictureDto picture)
        {
            var pictureEntity = _context.Pictures.Include(p => p.IdPlaces).FirstOrDefault(p => p.IdPicture == picture.IdPicture);
            if (pictureEntity == null)
                return null;
            pictureEntity.Name = picture.Name;
            pictureEntity.Link = picture.Link;
            pictureEntity.IdPlaces.Clear();
            foreach (var placeId in picture.Places)
            {
                var placeEntity = _context.Places.Find(placeId);
                if (placeEntity != null)
                {
                    pictureEntity.IdPlaces.Add(placeEntity);
                }
            }
            _context.SaveChanges();
            return picture;
        }

        public bool Delete(int id)
        {
            var pictureEntity = _context.Pictures
                .Include(p => p.IdPlaces)
                .ThenInclude(p => p.IdPictures)
                .SingleOrDefault(p => p.IdPicture == id);
            if (pictureEntity == null)
                return false;
            foreach (var place in pictureEntity.IdPlaces)
            {
                place.IdPictures.Remove(pictureEntity);
            }
            _context.Pictures.Remove(pictureEntity);
            _context.SaveChanges();
            return true;
        }

    }
}
    
