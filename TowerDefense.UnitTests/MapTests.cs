using TowerDefense.Logic;
using System.Linq;

using FluentAssertions;
namespace TowerDefense.UnitTests;

public class MapTests
{
    [Theory]
	[InlineData(10, 40)]
	[InlineData(3,12)]
	[InlineData(13,32)]
	public void ints_Should_Match_Size_Of_Array(int expectedWidth, int expectedHeight)
    {
        //Arrange
        Map map = new Map(expectedWidth, expectedHeight, (3,4));

        //Act
        int actualWidth = map.Width;
        int actualHeight = map.Height;

		//Assert
		actualWidth.Should().Be(expectedWidth);
		actualHeight.Should().Be(expectedHeight);
	}
	[Theory]
	[InlineData(0, 0)]
	[InlineData(0, 1)]
	[InlineData(1, 0)]
	[InlineData(10, -5)]
	[InlineData(-5, 10)]
	public void Construction_ShouldThrowArgumentException_WhenInvalidMapSize(int attemptedWidth, int attemptedHeight)
	{
		// Arrange
		Action create = () => new Map(attemptedWidth, attemptedHeight, (3,4));

		// Act

		// Assert
		create.Should().ThrowExactly<ArgumentException>().WithMessage("*cannot be <= 0*");
	}

	[Theory]
	[InlineData(3, 3)]
	[InlineData(4, 4)]
	[InlineData(0, 0)]
	public void GetAndSetBoardContents_ShouldWorkCorrectly_WithValidInput(int x, int y)
	{
		//Arrange
		Map map = new Map(10,10, (3,4));
		MapTile expectedValue = new MapTile();

		//Act
		map.SetBoardContents(x, y, expectedValue);
		var actualValue = map.GetBoardContents(y, x);

		//Assert
		Assert.Equal(expectedValue, actualValue);
	}

	[Theory]
	[InlineData(10, 10, 4, 4)]
	public void EnemySpawnPoint_Should_Be_Correctly_Passed(int x, int y, int enemySpawnPointX, int enemySpawnPointY)
	{

		//Arrange
		(int, int) enemySpawnPoint = new(enemySpawnPointX, enemySpawnPointY);
		Map map = new Map(x, y, enemySpawnPoint);

		//Act

		//Assert
		map.EnemySpawnPoint.Should().Be(enemySpawnPoint);

	}
	[Theory]
	[InlineData(10, 10, -7, 1)]
	[InlineData(10, 10, 3, -3)]
	[InlineData(10, 10, -7, -7)]
	public void EnemySpawnPoint_Should_ThrowArgumentException_WhenInvalid(int x, int y, int enemySpawnPointX, int enemySpawnPointY)
	{
		// Arrange
		(int, int) enemySpawnPoint = (enemySpawnPointX, enemySpawnPointY);

		// Act
		Action act = () => new Map(x, y, enemySpawnPoint);

		// Assert
		act.Should().Throw<ArgumentException>().WithMessage("*Input cant be negative*");
	}
}