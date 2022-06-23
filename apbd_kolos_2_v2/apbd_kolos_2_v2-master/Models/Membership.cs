using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_kolos_2_v2.Models
{
    public class Membership
    {
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        [ForeignKey("Team")]     
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public DateTime MembershipSince { get; set; }
    }
}