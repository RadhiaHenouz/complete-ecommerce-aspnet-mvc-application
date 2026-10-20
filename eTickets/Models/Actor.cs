using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Profile Picture URL")]
        [Required(ErrorMessage ="Profile picture is required!")]
        public String  ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required!")]
        [StringLength (50,MinimumLength =5,ErrorMessage ="Full Name must be 3 and 50 chars!")]
        public String  FullName{ get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required!")]
        public String Bio { get; set; }

        //Relationships 
        public List<Actor_Movie> Actors_Movies { get; set; }=new List<Actor_Movie>();
    }
}
