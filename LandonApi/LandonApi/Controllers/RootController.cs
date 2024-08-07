using Asp.Versioning;
using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LandonApi.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        [ApiVersion("1.0")]
        public IActionResult GetRoot()
        {
            var response = new
            {
                // ion compatiable json
                href = Url.Link(nameof(GetRoot), null),

                rooms = new
                {
                    href = Url.Link(nameof(RoomController.GetRooms), null)
                },

                hoteInfo = new
                {
                    href = Url.Link(nameof(InfoController.GetInfo), null)
                }
            };

            return Ok(response);
        }
    }
}
