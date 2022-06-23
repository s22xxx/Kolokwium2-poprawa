

namespace apbd_kolos_2_v2.Models.DTOs
{
    public class Team
    {
       
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        
        public ICollection<Member> Members { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }
    }

    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? NickName { get; set; }
    }
}