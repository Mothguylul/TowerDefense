using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Logic;

namespace TowerDefense.Logic
{
	public class WaveManager
	{
		public bool isWaveEnded { get; private set; } = false;

		public bool isWaveStarted { get; private set; }

		public List<Wave> Waves { get; set; }

		public int WavesCount { get; set; } = 0;

		public WaveManager(List<Wave> waves, int wavesCount = 0) 
		{
			Waves = waves;
			WavesCount = wavesCount;
		}
	}
}
