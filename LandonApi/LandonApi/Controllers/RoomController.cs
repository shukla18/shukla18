using Microsoft.AspNetCore.Mvc;

namespace LandonApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        [HttpGet(Name = nameof(GetRooms))]
        public ActionResult GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
