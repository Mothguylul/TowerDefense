using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Logic
{
	/// <summary>
	/// Represents one Square at the Board
	/// </summary>
	public class MapTile
	{
		public bool EnemyCanWalk {  get; set; }

		public bool CanPlaceTower { get; set; }

		public MapTile()
		{



		}
	}
}
