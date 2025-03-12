using System.ComponentModel.DataAnnotations;

namespace UsApi.Models
{
    public class Ball
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
