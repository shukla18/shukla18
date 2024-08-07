using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LandonApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController :ControllerBase
    {
        private readonly HoteInfomation _hotelInformation;

        public InfoController(IOptions<HoteInfomation> options)
        {
            _hotelInformation = options.Value;
                
        }
        [HttpGet(Name = nameof(GetInfo))]
        public ActionResult<HoteInfomation>GetInfo()
        {
            _hotelInformation.Href = Url.Link(nameof(GetInfo), null);

            return _hotelInformation;
        }
    }
}
