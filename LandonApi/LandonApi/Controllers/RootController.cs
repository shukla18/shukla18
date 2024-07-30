using Microsoft.AspNetCore.Mvc;

namespace LandonApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                // ion compatiable json
                href = Url.Link(nameof(GetRoot), null),

                rooms = new
                {
                    href = Url.Link(nameof(RoomController.GetRooms), null)
                }
            };

            return Ok(response);
        }
    }
}
