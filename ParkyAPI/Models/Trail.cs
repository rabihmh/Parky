﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkyAPI.Models
{
    public class Trail
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double distance { get; set; }

        public enum DifficultyType{Easy,Moderate,Difficult,Expert}

        public DifficultyType Difficulty { get; set; }

        public int NationalParkId { get; set; }

        [ForeignKey("NationalParkId")]

        public NationalPark NationalPark { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
