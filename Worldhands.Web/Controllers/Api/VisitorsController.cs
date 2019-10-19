using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Worldhands.Common.Models;
using Worldhands.Web.Data;

namespace Worldhands.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VisitorsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public VisitorsController(
            DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        [HttpPost]
        [Route("GetVisitorByEmail")]
        public async Task<IActionResult> GetVisitorByEmailAsync(EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var visitor = await _dataContext.Visitors
                .Include(u => u.User)
                .FirstOrDefaultAsync(o => o.User.Email.ToLower() == request.Email.ToLower());
            if (visitor == null)
            {
                return NotFound();
            }
            return Ok(visitor);
        }
    }
}