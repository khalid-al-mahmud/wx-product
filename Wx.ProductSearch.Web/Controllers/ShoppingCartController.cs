using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wx.ProductSearch.Application;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartProcess _shoppingCartProcess;


        public ShoppingCartController(IShoppingCartProcess shoppingCartProcess)
        {
            _shoppingCartProcess = shoppingCartProcess;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            
            var usr = new TestUser { Name= "Khalid Al Mahmud", Token= "e63ecdce-367b-48a6-a8e6-4a3e97046d27" };
            return Ok(usr);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> SortProduct([FromQuery] string sortOption )
        {
            try
            {
                var products = await _shoppingCartProcess.SortProducts(sortOption);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500,"Something went wrong");
            }
        }

       

        [HttpPost("trolleyTotal")]
        public async Task<IActionResult> TrolleyTotal([FromBody] Trolly trolly)
        {
            try
            {
                if (trolly == default(Trolly))
                    return BadRequest("Trolly required");

                var cartTotal = await _shoppingCartProcess.CalculateShoppingCart(trolly);
                return Ok(cartTotal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

    }
}
