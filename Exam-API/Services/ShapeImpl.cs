using System.Text.Json;
using Exam_API.Model;

namespace Exam_API.Services;

public class ShapeImpl : IShape
{
    public void Add(Shape shape)
    {
        var filePath = $"Saves/shape_{shape.getId()}.json";
        if (!File.Exists(filePath))
        {
            var jsonString = JsonSerializer.Serialize(shape);
            File.WriteAllText(filePath, jsonString);
        }
        else
        {
            throw new Exception("Shape already exists");
        }
    }
}