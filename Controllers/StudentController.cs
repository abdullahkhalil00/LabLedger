using LabLedger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LabLedger.Controllers
{
    public class StudentController : Controller
    {
        private readonly IEquipmentCatalog _equipmentCatalog;

        public StudentController(IEquipmentCatalog equipmentCatalog)
        {
            _equipmentCatalog = equipmentCatalog;
        }

        public IActionResult Dashboard() => View("Dashbord");

        public IActionResult Dashbord()
        {
            return View();
        }

        public IActionResult Equipment()
        {
            var result = _equipmentCatalog.GetAllEquipments();
            return View(result);
        }

        public IActionResult EquipmentDetails(int? id) => View();

        public IActionResult EquipmentDetail(int? id) =>
            RedirectToAction(nameof(EquipmentDetails), new { id });

        public IActionResult MyReservations() => View();

        public IActionResult MyBorrowedEquipment() => View();

        public IActionResult ReportDamage() => View();

        public IActionResult Profile() => View();
    }
}