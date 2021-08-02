using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetailsApi.Models;
using UserDetailsApi.Repository;

namespace UserDetailsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IEnumerable<UserDetails> GetAllUserDetails()
        {
            return _userRepo.GetUserDetails();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userRepo.GetUserDetailsById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserDetails user)
        {
            try
            {
                var adduser = await _userRepo.PostUser(user);
                return Ok(adduser);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateUser(int id,UserDetails user)
        {
            try
            {
                var updateuser = await _userRepo.UpdateUser(id, user);
                return Ok(updateuser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
