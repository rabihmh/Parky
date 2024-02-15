using System.ComponentModel.DataAnnotations;

namespace ParkyAPI.Models.DTOs
{
    public class NationalParkDto
    {
        
        public string Name { get; set; }

        public string State { get; set; }

        public DateTime Created { get; set; }

        public DateTime Established { get; set; }
    }
}
