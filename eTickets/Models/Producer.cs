using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public String ProfilePictureURL { get; set; }
        public String FullName { get; set; }
        public String Bio { get; set; }

        //Relationships 
        public List<Movie> Movies { get; set; }
    }
}
