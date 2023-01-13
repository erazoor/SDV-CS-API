using Exam_API.Model;

namespace Exam_API.Services
{
    public interface IDrawing
    {
        void Add(Drawing drawing);
        void Update(Drawing drawing, int id);
        void Delete(int id);
        Drawing Get(int id);
        IEnumerable<Drawing> GetAll();
    }
}