using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_kolos_2_v2.Models
{
    public class Member
    {
        
        [Key]
        public int MemberId { get; set; }

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [MaxLength(20)]
        public string MemberName { get; set; }
        [MaxLength(50)]
        public string MemberSurname { get; set; }
        [MaxLength(20)]
        public string? MemberNickName { get; set; }
       
        public virtual ICollection<Team> Teams { get; set; }
    }
}