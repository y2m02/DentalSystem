﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class Odontogram
    {
        [Key] public int OdontogramId { get; set; }
        [ForeignKey("Visit")] public int VisitId { get; set; }
        [Required] public string Information { get; set; }
        [Required] public int CavitiesQuantity { get; set; }

        public Visit Visit { get; set; }
        public TreatmentOdontogram TreatmentOdontogram { get; set; }
    }
}