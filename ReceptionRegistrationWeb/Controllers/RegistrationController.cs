using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptionRegistrationWeb.Models;

namespace ReceptionRegistrationWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly WebDbContext.WebDbContext _dbContext;

        public RegistrationController (WebDbContext.WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //-------------------------------------------------------------------------------------------------------------

        [Route("/callRecorder")]
        public IActionResult CallRecorder()
        {
            return View();
        }

        [HttpGet("GetCustomerCallRecorder")]
        public IActionResult GetCustomerCallRecorder()
        {
            var callrcuser = _dbContext.tblCallRecorderCustomers.ToList();
            return Ok(new { data = callrcuser });
        }

        [HttpPost("CreateCustomerCallRecorder")]
        public IActionResult CreateCustomerCallRecorder([FromBody] CallRecorderCustomer customer)
        {
            _dbContext.tblCallRecorderCustomers.Add(customer);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateCustomerCallRecorder")]
        public IActionResult UpdateCustomerCallRecorder([FromBody] CallRecorderCustomer customer)
        {
            var existingCustomer = _dbContext.tblCallRecorderCustomers.Find(customer.Id);
            if (existingCustomer == null)
                return NotFound();

            existingCustomer.FullName = customer.FullName;
            existingCustomer.Subject = customer.Subject;
            existingCustomer.VehicleOfInterestandModel = customer.VehicleOfInterestandModel;
            existingCustomer.PackageEngine = customer.PackageEngine;
            existingCustomer.TransferredPerson = customer.TransferredPerson;
            existingCustomer.Location = customer.Location;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Notes = customer.Notes;
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteCustomerCallRecorder/{id}")]
        public IActionResult DeleteCustomerCallRecorder(Guid id)
        {
            var customer = _dbContext.tblCallRecorderCustomers.Find(id);
            if (customer == null)
                return NotFound();

            _dbContext.tblCallRecorderCustomers.Remove(customer);
            _dbContext.SaveChanges();
            return Ok();
        }


        //-------------------------------------------------------------------------------------------------------------

        [Route("/showroom")]
        public IActionResult Showroom()
        {
            return View();
        }

        [HttpGet("GetCustomerShowroom")]
        public IActionResult GetCustomerShowroom()
        {
            var shwuser = _dbContext.tblShowroomCustomers.ToList();
            return Ok(new { data = shwuser });
        }

        [HttpPost("CreateCustomerShowroom")]
        public IActionResult CreateCustomerShowroom([FromBody] ShowroomCustomer customer)
        {
            _dbContext.tblShowroomCustomers.Add(customer);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateCustomerShowroom")]
        public IActionResult UpdateCustomerShowroom([FromBody] ShowroomCustomer customer)
        {
            var existingCustomer = _dbContext.tblShowroomCustomers.Find(customer.Id);
            if (existingCustomer == null)
                return NotFound();

            existingCustomer.FullName = customer.FullName;
            existingCustomer.Subject = customer.Subject;
            existingCustomer.VehicleOfInterest = customer.VehicleOfInterest;
            existingCustomer.Location = customer.Location;
            existingCustomer.SalesConsultant = customer.SalesConsultant;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Notes = customer.Notes;
            existingCustomer.SystemRegistrationInformation = customer.SystemRegistrationInformation;
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteCustomerShowroom/{id}")]
        public IActionResult DeleteCustomerShowroom(Guid id)
        {
            var customer = _dbContext.tblShowroomCustomers.Find(id);
            if (customer == null)
                return NotFound();

            _dbContext.tblShowroomCustomers.Remove(customer);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
