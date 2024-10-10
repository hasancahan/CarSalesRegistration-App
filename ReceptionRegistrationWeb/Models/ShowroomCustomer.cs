namespace ReceptionRegistrationWeb.Models
{
    public class ShowroomCustomer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string VehicleOfInterest { get; set; }
        public string Location { get; set; }
        public string SalesConsultant { get; set; }
        public string PhoneNumber { get; set; }
        public string SystemRegistrationInformation { get; set; }
        public DateTime DateandTime { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }

    }
}