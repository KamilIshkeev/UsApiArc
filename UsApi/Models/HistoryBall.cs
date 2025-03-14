using System.ComponentModel.DataAnnotations;

namespace UsApi.Models
{
    public class HistoryBall
    {
        [Key]
        public int Id { get; set; }
        public int? User_id { get; set; }
        public int? Ball_id { get; set; }
    }
}
