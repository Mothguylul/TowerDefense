
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Remoting;

namespace TowerDefense.Logic;

public class Map
{
	private readonly MapTile[,] _board;

	public int Width => _board.GetLength(0);

	public int Height => _board.GetLength(1);

	public (int X, int Y) EnemySpawnPoint { get; private set; }

	public (int X, int Y) StartPoint { get; private set; }

	public (int X, int Y) EndPoint { get; private set; }

	/// <summary>
	/// The List of the valid Places at the Beginning
	/// </summary>
	public List<(int x, int y)> ValidStartTowerPlaces { get; private set; }

	/// <summary>
	/// The List of the valid Tower Places through the Game, will be changed 
	/// </summary> 
	public List<(int x, int y)> ValidTowerPlaces { get; set; }

	public Map(MapTile[,] validBoard)
	{
		if (validBoard is null)
			throw new ArgumentNullException();

		ValidateBoard(validBoard);

		_board = validBoard;
	}


	/// <summary>
	/// Gets a Value on the Board by the given Y and X values
	/// </summary>
	/// <param name="y"></param>
	/// <param name="x"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	public MapTile? GetBoardContents(int y, int x)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
			return null;
		else
			return _board[y, x];
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="board"></param>
	/// <exception cref="ValidationException"></exception>
	private void ValidateBoard(MapTile[,] board)
	{
		int startpoints = 0;
		int endpoints = 0;

		int height = board.GetLength(1);  
		int width = board.GetLength(0); 

		for (int x = 0; x < width; x++)  
		{
			for (int y = 0; y < height; y++)  
			{
				var tile = board[x, y];

				Debug.WriteLine($"Inspecting tile at ({x}, {y}): IsStartPoint={tile.IsStartPoint}, IsEndPoint={tile.IsEndPoint}");

				if (tile.IsStartPoint)
				{
					startpoints++;
					StartPoint = (x, y);
					Debug.WriteLine($"StartPoint found at ({x}, {y})");
				}

				if (tile.IsEndPoint)
				{
					endpoints++;
					EndPoint = (x, y);
					Debug.WriteLine($"EndPoint found at ({x}, {y})");
				}
			}
		}

		if (startpoints != 1)
			throw new ValidationException("Exactly one StartPoint must be defined.");
		if (endpoints != 1)
			throw new ValidationException("Exactly one EndPoint must be defined.");
	}

	/// <summary>
	/// Sets a Value to the given Y and X values
	/// </summary>
	/// <param name="y"></param>
	/// <param name="x"></param>
	/// <param name="value"></param>
	/// <exception cref="ArgumentException"></exception>
	public void SetBoardContents(int x, int y, MapTile value)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
			throw new ArgumentException("Inputs must be valid");
		else
			_board[y, x] = value;

	}
}
