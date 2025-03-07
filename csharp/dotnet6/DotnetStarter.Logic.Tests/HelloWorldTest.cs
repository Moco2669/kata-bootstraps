using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class HelloWorldTest
    {
        [Fact]
        public void Hello_ReturnsWorld() => Assert.Equal("World!", HelloWorld.Hello());
        
        [Fact]
        public void MainTest()
        {
            Grid grid = new Grid(20, 25);
            grid.AddObstacle(3, 4);
            grid.AddObstacle(4, 4);
            grid.AddObstacle(20, 20);
            Rover rover = new Rover(grid);
            rover.ExecuteCommands("RMMLML");
            Assert.Equal("2:1:W",rover.GetReport());
        }
    }
}