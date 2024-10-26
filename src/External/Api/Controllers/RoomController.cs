using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController (RoomServices services): ControllerBase
    {
        [HttpGet]
        [Route("GetAllRoom")]
        public async Task<IActionResult> GetAll()
        {
            var data = await services.GetAll();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetRoomById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await services.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateNewRoom")]
        public async Task<IActionResult> Create(Room Rom)
        {
            var data = await services.Create(Rom);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateRoom")]
        public async Task<IActionResult> Update(Room rom)
        {
            var data = await services.Update(rom);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteRoom")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = services.Delete(id);
            return Ok(data);
        }
    }
}
