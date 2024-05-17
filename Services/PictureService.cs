using BioKudi.dto;
using BioKudi.Repository;

namespace BioKudi.Services
{
    public class PictureService
    {
        private readonly PictureRepository picRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PictureService(PictureRepository picRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.picRepo = picRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public PictureDto GetPicture(int id)
        {
            return picRepo.GetPicture(id);
        }

        public IEnumerable<PictureDto> GetAllPictures()
        {
            return picRepo.GetListPicture() ?? new List<PictureDto>();
        }

        public PictureDto CreatePicture(PictureDto picture)
        {
            var result = picRepo.Create(picture);
            if (result == null)
            {
                return null;
            }
            return picture;
        }

        public PictureDto UpdatePicture(PictureDto picture)
        {
            var result = picRepo.Update(picture);
            if (result == null)
            {
                return null;
            }
            return picture;
        }

        public bool DeletePicture(int id)
        {
            return picRepo.Delete(id);
        }
    }
}
