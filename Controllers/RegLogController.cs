using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegLogin.DataModel;

namespace RegLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegLogController : ControllerBase
    {
        RegisterContext db = new RegisterContext();

        [HttpGet]
        [Route("spGetLogin")]
        public ActionResult GetLogin(int id)
        {
            try
            {
                var log = db.Set<Login>().Where(w => w.Id == id).Select(c => new Login
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email,
                    Password = c.Password
                });
                return Ok(log);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("spInsertLogin")]
        public ActionResult PostLogin(Login user)
        {
            try
            {
                var reg = db.Set<Login>().FirstOrDefault(w => w.Id == user.Id);

                if (reg != null)
                {
                    reg.Name = user.Name;
                    reg.PhoneNumber = user.PhoneNumber;
                    reg.Email = user.Email;
                    reg.Password = user.Password;
                    db.SaveChanges();
                }
                else
                {
                    var log = new Login();
                    log.Name = user.Name;
                    log.PhoneNumber = user.PhoneNumber;
                    log.Email = user.Email;
                    log.Password = user.Password;
                    log.IsActive = user.IsActive;
                    db.Add(log);
                    db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }
    }
}
