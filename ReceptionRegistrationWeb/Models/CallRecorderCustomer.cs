namespace ReceptionRegistrationWeb.Models
{
    public class CallRecorderCustomer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string VehicleOfInterestandModel { get; set; }
        public string PackageEngine { get; set; }
        public string TransferredPerson { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateandTime { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }
    }
}
