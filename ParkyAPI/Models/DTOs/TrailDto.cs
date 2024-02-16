using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkyAPI.Models.DTOs
{
    public class TrailDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double distance { get; set; }

        public Trail.DifficultyType Difficulty { get; set; }


        public int NationalParkId { get; set; }


        public NationalParkDto NationalParkDto { get; set; }

    }
}
