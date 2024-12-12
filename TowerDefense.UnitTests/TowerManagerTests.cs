using FluentAssertions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Logic;

namespace TowerDefense.UnitTests
{
	public class TowerManagerTests
	{
		[Theory]
		[InlineData(3, 5)]
		public void SellShould_RemoveTowerFromTowerManagerList(int x, int y)
		{
			// Arrange
			(int x, int y) enemySpawnPoint = (2, 1);
			Map map = new Map(x, y, enemySpawnPoint);
			Tower tower = new Tower(new MapTile(), x, y);
			TowerManager towerManager = new TowerManager(map);
			towerManager.BuildTower(x, y);

			// Act
			towerManager.SellTower(x, y);
			var towerInList = towerManager.Towers.FirstOrDefault(t => t.X == x && t.Y == y);

			// Assert
			towerInList.Should().BeNull();

		}

		[Theory]
		[InlineData(3, 5)]
		public void BuildTower_Should_Add_Tower_To_List(int x, int y)
		{
			// Arrange
			(int x, int y) enemySpawnPoint = (2, 1);
			Map map = new Map(x, y, enemySpawnPoint);
			Tower tower = new Tower(new MapTile(), x, y);
			TowerManager towerManager = new TowerManager(map);

			// Act
			towerManager.BuildTower(x, y);
			var towerInList = towerManager.Towers.FirstOrDefault(t => t.X == x && t.Y == y);


			// Assert
			towerInList.Should().NotBeNull();
		}
	}
}
