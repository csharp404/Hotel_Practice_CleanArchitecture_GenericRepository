using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class GuestController(GuestServices services) : ControllerBase
    {
        [HttpGet]
        [Route("GetAllGuests")]
        public async Task<IActionResult> GetAll()
        {
            var data = await services.GetAll();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetGuestById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data =await services.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateNewGuest")]
        public async Task<IActionResult> Create(Guest gst)
        {
            var data = await services.Create(gst);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateGuest")]
        public async Task<IActionResult> Update(Guest gst)
        {
            var data = await services.Update(gst);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteGuest")]
        public async Task<IActionResult> Delete(int id)
        {
            var data =  services.Delete(id);
            return Ok(data);
        }
    }

