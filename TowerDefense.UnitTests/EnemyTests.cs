using FluentAssertions;
using TowerDefense.Logic;
using TowerDefense.UnitTests;

public class EnemyTests(MapFixture fixture) : IClassFixture<MapFixture>
{
	private readonly Map _validMap = new(fixture.ValidBoard);

	[Fact]
	public void Should_SpawnAtStartPoint()
	{
		// Arrange
		var enemy = new Enemy(_validMap);

		// Act
		var positionBeforeSpawn = enemy.Position;
		enemy.Spawn();
		var positionAfterSpawn = enemy.Position;

		// Assert
		positionBeforeSpawn.Should().BeNull();
		positionAfterSpawn.Should().Be(_validMap.StartPoint);
	}

	[Fact]
	public void Should_InvokeEventWhenSpawned()
	{
		// Arrange
		var enemy = new Enemy(_validMap);

		// Act
		var monitor = enemy.Monitor();
		enemy.Spawn();

		// Assert
		monitor.Should().Raise(nameof(Enemy.EnemySpawned)).WithArgs<Enemy>(e => e == enemy);
	}

	[Fact]
	public void FindNextSquare_Should_Work_Correctly()
	{
		// Arrange
		var enemy = new Enemy(_validMap);
		enemy.Spawn();
	
		// Act
		enemy.FindNextSquare();

		// Assert
		enemy.Position.Should().Be((1, 1));

	}
}