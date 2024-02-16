
using System.ComponentModel.DataAnnotations;

namespace ParkyAPI.Models.DTOs
{

    public class TrailUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double distance { get; set; }

        public Trail.DifficultyType Difficulty { get; set; }


        public int NationalParkId { get; set; }

    }
}
