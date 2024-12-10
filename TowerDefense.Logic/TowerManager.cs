using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Logic
{
	public class TowerManager
	{
		public readonly List<Tower> Towers = new List<Tower>();

		private Map _map;

		public TowerManager()
		{
		}

		private void SetNewMap(Map map)
		{
			Towers.Clear();

			_map = map;
		}

		public Tower? BuildTower(int x, int y)
		{
			MapTile? tile = _map.GetBoardContents(x, y);

			if (tile is not null && tile.CanPlaceTower)
			{
				Tower tower = new Tower(tile, x, y);
				Towers.Add(tower);
				return tower;
			}

			return null;
		}

		public void SellTower(int x, int y)
		{
			var findTower = Towers.FirstOrDefault(t => t.X ==  x && t.Y == y);
			Towers.Remove(findTower);

			// add cash later
		}
	}
}
