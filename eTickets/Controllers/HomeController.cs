using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;
public class HomeController : Controller
    {
        private readonly IActorsService _service;