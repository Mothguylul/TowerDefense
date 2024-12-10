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
			Tower tower = new Tower(new MapTile(),x,y);
			TowerManager towerManager = new TowerManager();
			towerManager.Towers.Add(tower);

			// Act
			towerManager.SellTower(x,y);
			var towerInList = towerManager.Towers.FirstOrDefault(t => t.X == x && t.Y == y);

			// Assert
			Assert.True(towerInList == null);

		}
	}
}
