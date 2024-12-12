using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Logic
{
	public class TowerManager
	{
		private readonly List<Tower> _towers;

		public IReadOnlyList<Tower>Towers => _towers;


		private Map _map;

		public TowerManager(Map map)
		{
			_towers = new List<Tower>();
			_map = map;
		}

		private void SetNewMap(Map map)
		{
			_towers.Clear();

			_map = map;
		}

		/// <summary>
		/// Builds a tower at a given place and checks if the place is null
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public Tower? BuildTower(int x, int y)
		{
			MapTile? tile = _map.GetBoardContents(x, y);

			if (tile is not null && tile.CanPlaceTower)
			{
				Tower tower = new Tower(tile, x, y);
				_towers.Add(tower);
				return tower;
			}

			return null;
		}

		/// <summary>
		/// Removes a Tower by the given coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void SellTower(int x, int y)
		{
			var findTower = Towers.FirstOrDefault(t => t.X ==  x && t.Y == y);
			_towers.Remove(findTower);

			// add cash later
		}
	}
}
