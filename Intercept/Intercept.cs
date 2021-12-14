using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intercept
{
    public class Intercept : ControllerBase
    {
        [NonAction]
        public IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public async Task<IActionResult> ExecuteAsync(Func<Task<object>> func)
        {
            try
            {
                var result = await func();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public Guid GetIdUsuarioLogado()
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var claim = claimsIdentity.FindFirst("Id");

                if (claim != null)
                    return Guid.Parse(claim.Value);

                return Guid.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
