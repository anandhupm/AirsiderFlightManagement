using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AirsiderFlightManagement.Areas.Flights.Controllers
{
    [Area("Flights")]
    [Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext db;

        public ScheduleController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.FlightSchedules.Include(m=>m.Flight).ToList());

        }


        [HttpGet]
        public IActionResult Create()
        {
            var x = db.Flights.ToList();
            var model = new ScheduleViewModel()
            {
                Flights = x,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ScheduleViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            db.FlightSchedules.Add(new FlightSchedule()
            {
                FlightFrom= model.FlightFrom,
                FlightTo= model.FlightTo,
                FlightDate= model.FlightDate,
                Cost= model.Cost,
                FlightId= model.Flight
            });
            await db.SaveChangesAsync();
            return RedirectToAction("create", "schedule", "flights");
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
                FlightName = flight.FlightName,
                FlightType = flight.FlightType,
                Discription = flight.Discription,
                TotalCapacity = flight.TotalCapacity
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
            flight.FlightName = model.FlightName;
            flight.FlightType = model.FlightType;
            flight.Discription = model.Discription;
            flight.TotalCapacity = model.TotalCapacity;
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
