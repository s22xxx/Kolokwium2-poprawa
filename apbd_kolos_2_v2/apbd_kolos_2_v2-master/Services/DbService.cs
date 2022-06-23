using apbd_kolos_2_v2.Data;
using apbd_kolos_2_v2.Models;
using apbd_kolos_2_v2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace apbd_kolos_2_v2.Services
{
    public class DbService : IDbService
    {
        private readonly DatabaseContext _context;

        public DbService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Team> GetTeamDTO(int teamId)
        {

            var exist= await _context.Teams.AnyAsync(x => x.TeamId == teamId);

            if (exist == false)
                return new Team {Message="brak",Code=404 };

            var Team = await _context.Teams.Include(t => t.Organization).FirstOrDefaultAsync(t => t.TeamId == teamId);
            if (Team == null)
            {

                return new Team { Message = "brak takiego teamu", Code = 404 };
            }





            var Memberss= await _context.Memberships.Where(x => x.TeamId == teamId).Select(x=>x.Member).ToListAsync();




            return new Models.DTOs.Team
            {
                TeamName = Team.TeamName,
                TeamDescription = Team.TeamDescription,
                OrganizationName = Team.Organization.OrganizationName,

                Members = Memberss
                .Select(x => new Models.DTOs.Member { FirstName = x.MemberName, LastName = x.MemberSurname, NickName = x.MemberNickName })
                .ToList()

           
            };

            
        }

        public async Task<PostDTO> PostMemberToTeam(int teamId, int memberId) 
        {


            var exist = await _context.Teams.AnyAsync(x => x.TeamId == teamId);

            if (exist == false)
                return new PostDTO { Code=404,Message="brak teamu"};

            var exist2 = await _context.Members.AnyAsync(x => x.MemberId == memberId);

            if (exist2 == false)
                return new PostDTO { Code = 404, Message = "brak membersa" };






         

            var membership = new Membership
            {
                MemberId = memberId,
                TeamId = teamId,
                MembershipSince = DateTime.Now
            };

            /// to sie psuje na sqlite
            _context.Memberships.Add(membership);
            ///

            await _context.SaveChangesAsync();

            return new PostDTO { Code=200,Message="Ok"}; // this always returns true, false is for futureproofing



        }
    }
}
