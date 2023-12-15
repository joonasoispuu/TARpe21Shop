using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21Shop.Core.Dto;

namespace TARpe21Shop.Core.ServiceInterface
{
    public interface IEmailService
    {
        void SendEmail(EmailDto dto);
    }
}