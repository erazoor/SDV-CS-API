using Exam_API.Model;
using Exam_API.Services;

namespace UnitTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestGetAll()
        {
            var result = new DrawingImpl();
            var i = result.ToString();
            Assert.IsNotEmpty(i);
        }
    }
}
