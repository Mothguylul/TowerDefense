using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using TowerDefense.Logic;

namespace TowerDefense.UnitTests;

public class MapTileTests
{
	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void IsWalkable_ShouldMatchConstructionParameter(bool inlineData)
	{
		// Arrange
		var tile = new MapTile(isWalkable: inlineData);

		// Act
		var result = tile.IsWalkable;

		// Act
		result.Should().Be(inlineData);
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void IsBuildable_ShouldBeOppositeOfIsWalkable(bool inlineData)
	{
		// Arrange
		var tile = new MapTile(isWalkable: inlineData);

		// Act
		var result = tile.IsBuildable;

		// Act
		result.Should().Be(!inlineData);
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void StartAndEndPoint_ShouldDefaultFalse(bool inlineData)
	{
		// Arrange
		var tile = new MapTile(isWalkable: inlineData);

		// Act
		var startResult = tile.IsStartPoint;
		var endResult = tile.IsEndPoint;

		// Assert
		startResult.Should().BeFalse();
		endResult.Should().BeFalse();
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void IsStartPoint_ShouldMatchConstructionParameters(bool inlineData)
	{
		// Arrange
		var tile = new MapTile(isWalkable: true, isStartPoint: inlineData);

		// Act
		var result = tile.IsStartPoint;

		// Assert
		result.Should().Be(inlineData);
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void IsEndPoint_ShouldMatchConstructionParameters(bool inlineData)
	{
		// Arrange
		var tile = new MapTile(isWalkable: true, isEndPoint: inlineData);

		// Act
		var result = tile.IsEndPoint;

		// Assert
		result.Should().Be(inlineData);
	}

	[Fact]
	public void IsStartPointAndIsEndPoint_CannotBothBeTrue()
	{
		// Arrange
		var createTile = () => new MapTile(isWalkable: true, isStartPoint: true, isEndPoint: true);

		// Assert
		createTile.Should().ThrowExactly<ValidationException>("A Start and an Endpoint cant be at the same point.");
	}

	[Fact]
	public void IsWalkableCannotBeFalse_IfStartPointOrEndPoint()
	{
		// Arrange
		var createUnwalkableStart = () => new MapTile(isWalkable: false, isStartPoint: true);
		var createUnwalkableEnd = () => new MapTile(isWalkable: false, isEndPoint: true);

		// Assert
		createUnwalkableStart.Should().ThrowExactly<ValidationException>("A Start and an Endpoint cant be at the same point.");
		createUnwalkableEnd.Should().ThrowExactly<ValidationException>("A Start and an Endpoint cant be at the same point.");
	}

}