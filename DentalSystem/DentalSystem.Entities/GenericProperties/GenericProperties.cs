using System.Collections.Generic;
using DentalSystem.Entities.Results.Patient;

namespace DentalSystem.Entities.GenericProperties
{
    public static class GenericProperties
    {
        public static int UserId => 1;
        public static int VisitId { get; set; }
        public static string UserName => "Admin";
   }
}