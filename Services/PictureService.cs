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

        public IEnumerable<PictureDto> GetAllPictures()
        {
            return picRepo.GetListPicture();
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
    }
}
