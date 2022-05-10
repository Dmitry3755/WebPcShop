using Microsoft.AspNetCore.Mvc;
using BackAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace BackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : Controller
    {
        private readonly PcShopContext db;

        public SuppliersController(PcShopContext pcShopContext)
        {
            db = pcShopContext;
        }

  
    }
}
