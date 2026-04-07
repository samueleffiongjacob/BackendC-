using Microsoft.AspNetCore.Mvc;
using System;

namespace ErrorHandlingProject.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandlingController : ControllerBase
    {
        [HttpGet("division")]
        public IActionResult GetDivisionResult(int numerator, int denominator)
        {
            try
            {
                var result = numerator / denominator;
                return Ok(new { Result = result }); // Return the result in a JSON format if no error occurs
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Attempted to divide by zero. Please provide a non-zero denominator.");
                // Return a user-friendly error message
                return BadRequest("Denominator cannot be zero. Please provide a valid denominator.");
            }
            // catch (Exception ex)
            // {
            //     // Log any other unexpected exceptions
            //     Log.Error(ex, "An unexpected error occurred.");

            //     // Return a generic error message
            //     return StatusCode(500, "An unexpected error occurred. Please try again later.");
            // }
        }
    }  
}