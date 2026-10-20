using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Profile picture")]
        [Required (ErrorMessage ="Profile Picture is required !")]
        public String ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required !")]
        public String FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required !")]
        public String Bio { get; set; }

        //Relationships 
        public List<Movie> Movies { get; set; }
    }
}
