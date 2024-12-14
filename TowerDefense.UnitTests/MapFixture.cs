using TowerDefense.Logic;

namespace TowerDefense.UnitTests;

/// <summary>
/// Helper Test Class to test Map/Maptile later
/// </summary>
public class MapFixture
{
	public MapTile[,] ValidBoard { get; private set; }

	public MapTile[,] BoardWithNoStartPoint { get; private set; }

	public MapTile[,] BoardWithNoEndPoint { get; private set; }

	public MapTile[,] BoardWithSameStartAndEnd { get; private set; }

	public MapFixture()
	{
		ValidBoard = new MapTile[3, 3]
		{
			{ new MapTile(false), new MapTile(true, isStartPoint: true), new MapTile(false) },
			{ new MapTile(false), new MapTile(true), new MapTile(false) },
			{ new MapTile(false), new MapTile(true, isEndPoint: true), new MapTile(false) },
		};

		BoardWithNoStartPoint = new MapTile[3, 3]
		{
			{ new MapTile(false), new MapTile(true), new MapTile(false) },
			{ new MapTile(false), new MapTile(true), new MapTile(false) },
			{ new MapTile(false), new MapTile(true, isEndPoint: true), new MapTile(false) },
		};

		BoardWithNoEndPoint = new MapTile[3, 3]
		{
			{ new MapTile(false), new MapTile(true, isStartPoint: true), new MapTile(false) },
			{ new MapTile(false), new MapTile(true), new MapTile(false) },
			{ new MapTile(false), new MapTile(true), new MapTile(false) },
		};
	}
}