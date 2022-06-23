using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_kolos_2_v2.Data;
using apbd_kolos_2_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolos_2_v2.Services
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext _dbContext;

        public TeamService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> TeamExists(int teamId)
        {
            return await _dbContext.Teams.FindAsync(teamId) != null;
        }

        public async Task<Models.Team> GetTeam(int teamId)
        {
            var team = await _dbContext.Teams.Include(t => t.Organization).FirstOrDefaultAsync(t => t.TeamId == teamId);
            if (team == null)
            {
                throw new Exception("Team not found"); // fallback protection against null ref
            }
            return team;
        }

        public async Task<Models.DTOs.Team> GetTeamDTO(int teamId)
        {
            var team = await GetTeam(teamId);
            
            var members = (from m in _dbContext.Members
                          join ms in _dbContext.Memberships on m.MemberId equals ms.MemberId
                          where ms.TeamId == teamId
                          select m).ToList();

            return new Models.DTOs.Team
            {
                TeamName = team.TeamName,
                TeamDescription = team.TeamDescription,
                OrganizationName = team.Organization.OrganizationName,
                Members = members.Select(m => new Models.DTOs.Member
                {
                    FirstName = m.MemberName,
                    LastName = m.MemberSurname,
                    NickName = m.MemberNickName != null ? m.MemberNickName : ""
                }).ToList()
            };
        }

        public async Task<bool> AddMemberToTeam(int teamId, int memberId)
        {
            var team = await GetTeam(teamId);
            var member = await _dbContext.Members.FindAsync(memberId); // how to use member service here?

            if (member == null)
            {
                throw new Exception("Member not found"); // fallback protection against null ref
            }

            if (team.Members.Any(m => m.MemberId == memberId))
            {
                return true; // member already in team
                // idk if this should be an error, if so replace with  "throw new Exception("Member already in team");"
                // and add a check for this in the controller (e.g. _service.IsMemberInTeam(teamId, memberId)))
            }
            
            var membership = new Membership
            {
                MemberId = memberId,
                TeamId = teamId,
                MembershipSince = DateTime.Now
            };

            /// to sie psuje na sqlite
            _dbContext.Memberships.Add(membership);
            ///

            await _dbContext.SaveChangesAsync();

            return true; // this always returns true, false is for futureproofing
        }

    }
}