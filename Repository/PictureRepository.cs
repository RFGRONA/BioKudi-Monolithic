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
            var pictureEntity = _context.Pictures.Find(id);
            if (pictureEntity == null)
                return null;
            var picture = new PictureDto
            {
                IdPicture = pictureEntity.IdPicture,
                Name = pictureEntity.Name,
                Link = pictureEntity.Link
            };
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
            var pictureEntity = _context.Pictures.Find(picture.IdPicture);
            if (pictureEntity == null)
                return null;
            pictureEntity.Name = picture.Name;
            pictureEntity.Link = picture.Link;
            _context.SaveChanges();
            return picture;
        }

        public PictureDto Delete(int id)
        {
            var pictureEntity = _context.Pictures.Find(id);
            if (pictureEntity == null)
                return null;
            _context.Pictures.Remove(pictureEntity);
            _context.SaveChanges();
            var picture = new PictureDto
            {
                IdPicture = pictureEntity.IdPicture,
                Name = pictureEntity.Name,
                Link = pictureEntity.Link
            };
            return picture;
        }

    }
}
    
