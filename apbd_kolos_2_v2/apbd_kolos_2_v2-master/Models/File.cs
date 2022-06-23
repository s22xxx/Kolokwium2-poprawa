using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_kolos_2_v2.Models
{
    public class File
    {
  
        public int FileId { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        [MaxLength(4)]
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
    }
}