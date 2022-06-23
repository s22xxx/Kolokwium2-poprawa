using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Models;

namespace apbd_kolos_2_v2.Services
{
    public interface ITeamService
    {
        public Task<bool> TeamExists(int teamId);
        public Task<Team> GetTeam(int teamId);
        public Task<Models.DTOs.Team> GetTeamDTO(int teamId);
        public Task<bool> AddMemberToTeam(int teamId, int memberId);
    }
}