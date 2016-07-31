using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial
{
    public class Photo
    {
        public Photo()
        {
        }

        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public string ThumbPath { get; set; }
        [Required]
        public DateTime? CreatedOn { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryPhoto Category { get; set; }
        public User User { get; set; }
    }
}
