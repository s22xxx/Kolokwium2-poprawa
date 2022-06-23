using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace apbd_kolos_2_v2.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        [MaxLength(50)]
        public string TeamName { get; set; }
        
        [MaxLength(500)]
        public string? TeamDescription { get; set; }
      

        public virtual ICollection<Member> Members { get; set; }
    }
}