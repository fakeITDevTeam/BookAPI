using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
                
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(13)")]
        public string ISBN { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Publisher {  get; set; } = string.Empty;

        public string Genre {  get; set; } = string.Empty;
    }
}
