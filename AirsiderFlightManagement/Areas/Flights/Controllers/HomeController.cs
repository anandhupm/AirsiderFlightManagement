using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AirsiderFlightManagement.Areas.Flights.Controllers
{
    [Area("Flights")]
    [Authorize(Roles = "Admin")]

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
  
        public IActionResult Index()
        {
            return View(db.Flights.ToList());

        }
      
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FlightRegisterView model)
        {
            if (!ModelState.IsValid)
                return View();
            db.Flights.Add(new Flight()
            {
                FlightNumber=model.FlightNumber,
                FlightName= model.FlightName,
                FlightType=model.FlightType,
                Discription=model.Discription,
                TotalCapacity=model.TotalCapacity
            });
            await db.SaveChangesAsync();
            return RedirectToAction("index","home","flights");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(new FlightRegisterView()
            {
                FlightName=flight.FlightName,
                FlightType=flight.FlightType,
                Discription=flight.Discription,
                TotalCapacity=flight.TotalCapacity
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(long id, FlightRegisterView model)
        {
            var flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            flight.FlightName= model.FlightName;
            flight.FlightType= model.FlightType;
            flight.Discription= model.Discription;
            flight.TotalCapacity= model.TotalCapacity;
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(long id)
        {
            var flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            db.Flights.Remove(flight);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
