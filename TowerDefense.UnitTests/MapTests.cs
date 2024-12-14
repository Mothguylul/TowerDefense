using System.ComponentModel.DataAnnotations;
using TowerDefense.Logic;
using FluentAssertions;

namespace TowerDefense.UnitTests;

public class MapTests : IClassFixture<MapFixture>
{
	private readonly MapTile[,] _validBoard;
	private readonly MapTile[,] _boardWithNoStartPoint;
	private readonly MapTile[,] _boardWithNoEndPoint;
	private readonly MapTile[,] _boardWithSameStartAndEnd;

	public MapTests(MapFixture fixture)
	{
		_validBoard = fixture.ValidBoard;
		_boardWithNoStartPoint = fixture.BoardWithNoStartPoint;
		_boardWithNoEndPoint = fixture.BoardWithNoEndPoint;
		_boardWithSameStartAndEnd = fixture.BoardWithSameStartAndEnd;
	}

	[Fact]
	public void Width_ShouldMatchArraySize()
	{
		//Arrange
		Map map = new(_validBoard);

		//Act
		var actualWidth = map.Width;

		//Assert
		actualWidth.Should().Be(_validBoard.GetLength(0));
	}

	[Fact]
	public void Height_ShouldMatchArraySize()
	{
		// Arrange
		Map map = new(_validBoard);

		// Act
		var actualHeight = map.Height;

		// Assert
		actualHeight.Should().Be(_validBoard.GetLength(1));
	}

	[Fact]
	public void Construction_ShouldThrowExceptionWithEmptyArray()
	{
		// Arrange
		var createEmptyMap = () => new Map(new MapTile[3, 3]);

		// Act

		// Assert
		createEmptyMap.Should().Throw<ValidationException>();
	}

	[Fact]
	public void Construction_ShouldThrowExceptionWithNullArray()
	{
		// Arrange
		var createNullMap = () => new Map(null);

		// Act

		// Assert
		createNullMap.Should().Throw<ArgumentNullException>();

	}

	[Fact]
	public void Construction_ShouldThrowExceptionWithNoStartPoint()
	{
		// Arrange
		var createMapWithNoStartPoint = () => new Map(_boardWithNoStartPoint);

		// Act

		// Assert
		createMapWithNoStartPoint.Should().Throw<ValidationException>();
	}
	[Fact]
	public void Construction_ShouldThrowExceptionWithNoEndPoint()
	{
		// Arrange
		var createMapWithNoEndPoint = () => new Map(_boardWithNoEndPoint);

		// Act

		// Assert
		createMapWithNoEndPoint.Should().Throw<ValidationException>();
	}

	/*[Fact]
	public void Construction_ShouldThrowExceptionWithSameStartAndEndPoint()
	{
		// Arrange
		var createMapWithSameStartAndEnd = () => new Map(_boardWithSameStartAndEnd);

		// Act

		// Assert
		createMapWithSameStartAndEnd.Should().Throw<ValidationException>();
	}*/

	[Fact]
	public void StartPoint_ShouldMatchSuppliedArray()
	{
		// Arrange
		Map map = new(_validBoard);

		// Act
		var result = map.StartPoint;

		// Assert
		result.Should().Be((0, 1));
	}

	[Fact]
	public void EndPoint_ShouldMatchSuppliedArray()
	{
		// Arrange
		Map map = new(_validBoard);

		// Act
		var result = map.EndPoint;

		// Assert
		result.Should().Be((2, 1));
	}
}