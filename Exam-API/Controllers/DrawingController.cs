using Exam_API.Model;
using Exam_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam_API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    
    public class DrawingController : Controller
    {
        private readonly IDrawing _drawing;
        
        public DrawingController(IDrawing drawing)
        {
            _drawing = drawing;
        }
        
        [HttpPost]
        public IActionResult CreateDrawing(Drawing drawing)
        {
            if(!ModelState.IsValid)
            {
                return Conflict(ModelState);
            }

            try
            {
                _drawing.Add(drawing);
                return CreatedAtAction("CreateDrawing", new { id = drawing.getId() }, drawing);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateDrawing([FromRoute] int id, [FromBody] Drawing drawing)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                _drawing.Update(drawing, id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet]
        public IActionResult GetDrawings()
        {
            try
            {
                return Ok(_drawing.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetDrawing(int id)
        {
            try
            {
                return Ok(_drawing.Get(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteDrawing(int id)
        {
            try
            {
                _drawing.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}