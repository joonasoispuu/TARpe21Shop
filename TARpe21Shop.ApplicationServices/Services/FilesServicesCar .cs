using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TARpe21Shop.Core.Domain;
using TARpe21Shop.Core.Dto;
using TARpe21Shop.Core.ServiceInterface;
using TARpe21Shop.Data;
using Microsoft.Extensions.Hosting;

namespace TARpe21Shop.ApplicationServices.Services
{
    public class FilesServicesCar : IFilesServicesCar
    {
        private readonly TARpe21ShopContext _context;
        private readonly IHostingEnvironment _webHost;

        public FilesServicesCar(TARpe21ShopContext context, IHostingEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public void UploadFilesToDatabase(CarDto dto, Car domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var file in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabaseCar files = new FileToDatabaseCar()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = file.FileName,
                            CarId = domain.Id
                        };

                        file.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FilesToDatabaseCar.Add(files);
                    }
                }
            }
        }
    }
}
