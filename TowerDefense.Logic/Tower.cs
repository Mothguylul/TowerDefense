using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Logic
{
	public class Tower
	{

		public readonly int X = new int();

		public readonly int Y = new int();

		private readonly MapTile _tile;

		public Tower(MapTile tile, int x, int y)
		{
			_tile = tile;
		}
	}
}
