using TARpe21Shop.Core.Domain;
using TARpe21Shop.Core.Dto;

namespace TARpe21Shop.Core.ServiceInterface
{
    public interface IFilesServicesCar
    {
        void UploadFilesToDatabase(CarDto dto, Car domain);
    }
}
