using Exam_API;

namespace Exam_API.Model
{
    public class Drawing
    {
        public static int Id { get; set; } 
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }
        public string Description { get; }
        
        
        public Drawing(string name, int width, int height, string description)
        {
            Id = getLastId() + 1;
            Name = name;
            Width = width;
            Height = height;
            Description = description;
        }
        
        public static int getLastId()
        {
            var files = Directory.GetFiles("Saves");
            var lastId = 0;
            if (files.Length == 0)
            {
                return lastId = 0;
            }
            foreach (var file in files)
            {
                var id = int.Parse(file.Split('_')[1].Split('.')[0]);
                if (id > lastId)
                {
                    lastId = id;
                }
            }
            return lastId;
        }

        public int getId()
        {
            return Id;
        }
        
        public int getById(int queryId)
        {
            var files = Directory.GetFiles("Saves");
            foreach (var file in files)
            {
                var id = int.Parse(file.Split('_')[1].Split('.')[0]);
                if (id == queryId)
                {
                    return id;
                }
            }
            return -1;
        }
    }
}