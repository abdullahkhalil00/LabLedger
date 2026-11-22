using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
	public IActionResult Dashboard() => View();

	public IActionResult Laboratories() => View();

	public IActionResult Equipment() => View();

	public IActionResult Categories() => View();

	public IActionResult Users() => View();

	public IActionResult Reports() => View();
}
