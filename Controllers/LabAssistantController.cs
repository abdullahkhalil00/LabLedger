using Microsoft.AspNetCore.Mvc;

public class LabAssistantController : Controller
{
	public IActionResult Dashboard() => View();

	public IActionResult ReservationRequests() => View();

	public IActionResult IssueEquipment() => View();

	public IActionResult ReturnEquipment() => View();

	public IActionResult MaintenanceRequests() => View();
}
