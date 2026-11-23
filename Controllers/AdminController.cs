
using Microsoft.AspNetCore.Mvc;
using LabRepo;
using Laboratory;
using AdminInterface;

public class AdminController : Controller
{
    public IActionResult Dashboard() => View();

    [HttpGet]
    public IActionResult Laboratories()
    {
        ILaboratores R = new LabRepository();

        var laboratories = R.GetAllLabs();

        return View(laboratories);
    }

    [HttpPost]
    public IActionResult Laboratories(
        string name,
        string location,
        string labcode,
        string labassistant,
        string description,
        bool status)
    {
        ILaboratores R = new LabRepository();

        R.CreateLab(name, location, labcode, labassistant, status, description);

        return RedirectToAction("Laboratories");
    }

    [HttpPost]
    public IActionResult UpdateLaboratory(
        int id,
        string name,
        string location,
        string labcode,
        string labassistant,
        string description,
        bool status)
    {
        ILaboratores R = new LabRepository();

        R.UpdateLab(id, name, location, labcode, labassistant, status, description);

        return RedirectToAction("Laboratories");
    }

    [HttpPost]
    public IActionResult DeleteLaboratory(int id)
    {
        ILaboratores R = new LabRepository();

        R.DeleteLab(id);

        return RedirectToAction("Laboratories");
    }

    public IActionResult Equipment() => View();

    public IActionResult Categories() => View();

    public IActionResult Users() => View();

    public IActionResult Reports() => View();
}
