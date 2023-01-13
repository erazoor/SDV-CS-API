using Exam_API.Model;
using Exam_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam_API.Controllers
{
    [ApiController]
    [Route("/api/v1/shape/[controller]")]
    
    public class ShapeController : Controller
    {
        private readonly IShape _shape;
        
        public ShapeController(IShape shape)
        {
            _shape = shape;
        }

        [HttpPost]
        public IActionResult CreateShape(Shape shape)
        {
            if (!ModelState.IsValid)
            {
                return Conflict(ModelState);
            }

            try
            {
                _shape.Add(shape);
                return CreatedAtAction("CreateShape", new { id = shape.getId() }, shape);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}