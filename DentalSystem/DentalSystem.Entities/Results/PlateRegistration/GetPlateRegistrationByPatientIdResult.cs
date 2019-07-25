namespace DentalSystem.Entities.Results.PlateRegistration
{
    public class GetPlateRegistrationByPatientIdResult
    {
        public int PlateRegistrationId { get; set; }
        public string PDB { get; set; }
        public string N16 { get; set; }
        public string N11 { get; set; }
        public string N26 { get; set; }
        public string N36 { get; set; }
        public string N32 { get; set; }
        public string N46 { get; set; }
        public string CT { get; set; }
        public string X { get; set; }
        public string RadiographicInterpretation { get; set; }
    }
}