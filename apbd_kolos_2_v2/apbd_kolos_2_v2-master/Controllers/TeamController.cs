using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_kolos_2_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IDbService _dbService;

        public TeamController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{teamId}")]
        public async Task<IActionResult> GetTeamAsync(int teamId)
        {

            var ret = _dbService.GetTeamDTO(teamId);

            return Ok(ret);
        }

        [HttpPost("{teamId}")]
        public async Task<IActionResult> AddMemberAsync(int teamId, int memberId)
        {
 
            var ret=_dbService.PostMemberToTeam(teamId, memberId);

            return Ok(ret);

        
        
        }
    }
}