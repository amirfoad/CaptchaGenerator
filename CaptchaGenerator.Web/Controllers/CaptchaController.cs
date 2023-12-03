using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using CaptchaGenerator.Web.HelperClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaptchaGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        [HttpGet("[action]")]
        public FileContentResult GetCaptcha()
        {
            FileContentResult result = null;
            var ci = new RandomCaptcha(PublicUtilities.GenerateRandomCode2(1,4), 350, 80);
            using (var stream = new MemoryStream())
            {
                ci.Image.Save(stream, ImageFormat.Jpeg);
                ci.Dispose();
                result = new FileContentResult(stream.ToArray(), "image/jpeg");
            }

            return result;
        }
    }
}
