using System.ComponentModel.DataAnnotations;

namespace PurpleTask.Models
{
    public class Category
    {
        public Category()
        {
            Cards = new List<Card>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Card>Cards { get; set; }
    }
}
