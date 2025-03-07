using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class HelloWorldTest
    {
        private Grid grid;
        private Rover rover;

        public HelloWorldTest()
        {
            grid = new Grid(20, 25);
            grid.AddObstacle(0, 4);
            grid.AddObstacle(3, 4); 
            grid.AddObstacle(4, 4);
            grid.AddObstacle(20, 20);
        }
        
        [Fact]
        public void Hello_ReturnsWorld() => Assert.Equal("World!", HelloWorld.Hello());

        [Fact]
        public void GridTest()
        {
            Assert.True(grid.IsObstacle(0, 4));
            Assert.True(grid.IsObstacle(3,4));
            Assert.True(grid.IsObstacle(4, 4));
            Assert.True(grid.IsObstacle(20, 20));
        }
        
        [Fact]
        public void MainTest()
        {
            rover = new Rover(grid);
            rover.ExecuteCommands("RMMLML");
            Assert.Equal("2:1:W", rover.GetReport());
        }

        [Fact]
        public void RoverStopsAtObstacle()
        {
            rover = new Rover(grid);
            rover.ExecuteCommands("MMMMMMMM");
            Assert.Equal("O:0:3:N", rover.GetReport());
        }
    }
}