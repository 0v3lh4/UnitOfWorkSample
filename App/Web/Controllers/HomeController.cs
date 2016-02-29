using CustomerAcquisition.Application;
using CustomerAcquisition.Application.Commands;
using Infrastructure.Data.ConnectionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
	public class HomeController : Controller
	{
		readonly CustomerService _customerService;
		readonly IConnectionRepository _connection;

		public HomeController(CustomerService customerService, IConnectionRepository connection)
		{
			_customerService = customerService;
			_connection = connection;
		}

		public ActionResult Index()
		{
			_connection.Save( "ConnectionString", "RepositoryKey" );

			NewCustomerCommand command = new NewCustomerCommand
			{
				RepositoryKey = "gdp2300",
				Number = "000.000.000-00",
				Firstname = "Fulano",
				Lastname = "Silva",
				AddressLine = "Endereço line 1",
				AddressLine2 = "Endereço line 2",
				AddressCode = "72440000"
			};

			_customerService.CreateCustomer( command );

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}