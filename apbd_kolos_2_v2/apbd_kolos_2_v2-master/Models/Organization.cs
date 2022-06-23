using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_kolos_2_v2.Models
{
    public class Organization
    {
       
        [Key]
        public int OrganizationId { get; set; }
        
        [MaxLength(100)]
        public string OrganizationName { get; set; }
    
        [MaxLength(50)]
        public string OrganizationDomain { get; set; }
  
        public virtual ICollection<Member> Members { get; set; }
      
        public virtual ICollection<Team> Teams { get; set; }
    }
}