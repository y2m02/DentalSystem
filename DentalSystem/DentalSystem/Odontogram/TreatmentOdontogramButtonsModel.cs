namespace DentalSystem.Odontogram
{
    public class TreatmentOdontogramButtonsModel
    {
        public int Id { get; set; }
        public string ButtonName { get; set; }
        public int ButtonNumber { get; set; }
        public bool HasCavities { get; set; }
        public int TeethStatus { get; set; }
    }
}