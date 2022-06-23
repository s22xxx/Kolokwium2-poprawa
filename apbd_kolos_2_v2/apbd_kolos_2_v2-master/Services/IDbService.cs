namespace apbd_kolos_2_v2.Services
{
    public interface IDbService
    {

        public Task<Models.DTOs.Team> GetTeamDTO(int teamId);

        public Task<bool> PostMemberToTeam(int teamId, int memberId);



    }
}
