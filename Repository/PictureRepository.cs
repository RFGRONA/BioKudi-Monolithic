using BioKudi.dto;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;

namespace BioKudi.Repository
{
    public class PictureRepository
    {
        private readonly BiokudiDbContext _context;
        private readonly PlaceRepository _placeRepository;
        public PictureRepository(BiokudiDbContext context, PlaceRepository placeRepository)
        {
            _context = context;
            _placeRepository = placeRepository;
        }

        public PictureDto Create(PictureDto picture)
        {
            try
            {
                var pictureEntity = new Picture
                {
                    Name = picture.Name,
                    Link = picture.Link,
                    PlaceId = picture.PlaceId
                };
                _context.Pictures.Add(pictureEntity);
                _context.SaveChanges();
                return picture;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public PictureDto GetPicture(int id)
        {
            try
            {
                var pictureEntity = _context.Pictures.Find(id);
                if (pictureEntity == null)
                    return null;
                var picture = new PictureDto
                {
                    IdPicture = pictureEntity.IdPicture,
                    Name = pictureEntity.Name,
                    Link = pictureEntity.Link,
                    PlaceId = pictureEntity.PlaceId
                };
                if(picture.PlaceId != null)
                {
                    var place = _placeRepository.GetPlace((int)picture.PlaceId);
                    picture.PlaceName = place != null ? place.NamePlace : null;
                }
                return picture;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public List<PictureDto> GetListPicture()
        {
            try
            {
                var pictures = _context.Pictures.ToList();
                var picturesDto = new List<PictureDto>();
                foreach (var picture in pictures)
                {
                    var pictureDto = new PictureDto
                    {
                        IdPicture = picture.IdPicture,
                        Name = picture.Name,
                        Link = picture.Link,
                        PlaceId = picture.PlaceId
                    };
                    picturesDto.Add(pictureDto);
                }
                return picturesDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public PictureDto Update(PictureDto picture)
        {
            try
            {
                var pictureEntity = _context.Pictures.Find(picture.IdPicture);
                if (pictureEntity == null)
                    return null;
                pictureEntity.Name = picture.Name;
                pictureEntity.Link = picture.Link;
                pictureEntity.PlaceId = picture.PlaceId;
                _context.SaveChanges();
                return picture;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var pictureEntity = _context.Pictures.Find(id);
                if (pictureEntity == null)
                    return false;
                _context.Pictures.Remove(pictureEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
    
