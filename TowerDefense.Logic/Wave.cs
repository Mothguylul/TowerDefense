using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Logic
{
	public class Wave
	{
		/// <summary>
		/// List of the type of the Enemys and of the amount of Enemys in that wave
		/// </summary>
		public readonly Dictionary<Enemy, int> TypeAndAmountOfWave = new Dictionary<Enemy, int>();
	}
}
