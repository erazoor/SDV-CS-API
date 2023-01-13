using Exam_API;

namespace Exam_API.Model
{
    public class Shape
    {
        public static int Id { get; set; } 
        public string Type { get; }
        public int Pos_x { get; }
        public int Pos_y { get; }
        public string Radius { get; }
        
        
        public Shape(string type, int pos_x, int pos_y, string radius)
        {
            Id = getLastId() + 1;
            Type = type;
            Pos_x = pos_x;
            Pos_y = pos_y;
            Radius = radius;
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