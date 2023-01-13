using Exam_API.Model;
using System.Text.Json;

namespace Exam_API.Services
{
    public class DrawingImpl : IDrawing
    {
        public DrawingImpl()
        {
            
        }
        public void Add(Drawing drawing)
        {
            var filePath = $"Saves/drawing_{drawing.getId()}.json";
            if (!File.Exists(filePath))
            {
                var jsonString = JsonSerializer.Serialize(drawing);
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                throw new Exception("Drawing already exists");
            }
        }

        public void Update(Drawing drawing, int id)
        {
            var filePath = $"Saves/drawing_{drawing.getById(id)}.json";
            if (File.Exists(filePath))
            {
                var drawingJson = JsonSerializer.Serialize(drawing);
                File.WriteAllText(filePath, drawingJson);
            }
            else
            {
                throw new FileNotFoundException("Drawing not found");
            }
        }

        public void Delete(int id)
        {
            var filePath = $"Saves/drawing_{id}.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new FileNotFoundException("Drawing not found");
            }
        }

        public Drawing Get(int id)
        {
            var filePath = $"Saves/drawing_{id}.json";
            if (File.Exists(filePath))
            {
                var drawingJson = File.ReadAllText(filePath);
                var drawing = JsonSerializer.Deserialize<Drawing>(drawingJson);
                return drawing;
            }
            else
            {
                throw new FileNotFoundException("Drawing not found");
            }
        }

        public IEnumerable<Drawing> GetAll()
        {
            var drawings = new List<Drawing>();
            var files = Directory.GetFiles("Saves");
            foreach (var file in files)
            {
                var drawingJson = File.ReadAllText(file);
                var drawing = JsonSerializer.Deserialize<Drawing>(drawingJson);
                drawings.Add(drawing);
            }
            return drawings;
        }
        
        public override string ToString()
        {
            return "Drawing";
        }
    }
}