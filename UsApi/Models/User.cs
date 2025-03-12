using System.ComponentModel.DataAnnotations;

namespace UsApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Money { get; set; }
        public int? Ball_id { get; set; }
        //public Ball Ball { get; set; }

    }
}
