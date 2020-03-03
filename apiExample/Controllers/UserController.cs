using apiExample.Models;
using apiExample.Services;
using Microsoft.AspNetCore.Cors; //cors
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace apiExample.Controllers
{
    [Route("api/")]
    [ApiController]
    [EnableCors("MyPolicy")] //cors
    public class UserController : ControllerBase
    {
        private readonly UserService service;

        public UserController(UserService userService)
        {
            service = userService;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            return service.Get();
        } 

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<UserModel> Get(string id)
        {
            var user = service.Get(id);

            if(user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<UserModel> Create(UserModel user)
        {
            service.Create(user);
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UserModel newUser)
        {
            var user = service.Get(id);

            if(user == null)
            {
                return NotFound();
            }

            service.Update(id, newUser);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = service.Get(id);

            if(user == null)
            {
                return NotFound();
            }

            service.Remove(user.Id);

            return NoContent();
        }
    }
}