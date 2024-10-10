namespace ReceptionRegistrationWeb.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public WorkTask WorkTask { get; set; }
    }
    public enum WorkTask
    {
        Reception = 0,
        SalesPerson = 1,
        Director = 2
    }
}
