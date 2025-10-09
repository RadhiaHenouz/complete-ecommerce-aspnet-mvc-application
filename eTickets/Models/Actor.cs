using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Profile Picture URL")]
        public String  ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public String  FullName{ get; set; }
        [Display(Name = "Biography")]
        public String Bio { get; set; }

        //Relationships 
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
