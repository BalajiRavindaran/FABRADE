using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FABRADE.Models
{
    public class fabradeTransaction
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? contact_name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? contact_no { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string? dress_type { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? size { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? age { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? gender { get; set; }
    }
}
