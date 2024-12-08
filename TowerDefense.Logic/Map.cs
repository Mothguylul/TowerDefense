﻿
using System.ComponentModel;
using System.Runtime.Remoting;

namespace TowerDefense.Logic;

public class Map
{
	private readonly object[,] _board;

	public int Width => _board.GetLength(0);

	public int Height => _board.GetLength(1);

	public (int X, int Y) EnemySpawnPoint { get; private set; }
	
	public (int X, int Y) StartPoint {  get; private set; }

	public (int X, int Y) EndPoint { get; private set; }

	public List<(int x, int y)> Path => FindPath();

	/// <summary>
	/// The List of the valid Places at the Beginning
	/// </summary>
	public List<(int x, int y)> ValidStartTowerPlaces { get; private set; } 

	/// <summary>
	/// The List of the valid Tower Places through the Game, will be changed 
	/// </summary> 
	public List<(int x, int y)> ValidTowerPlaces { get;  set; }

	public List<(int x, int y)> PlacedTowers { get;  set; } //NOTE: later maybe with return value Tower

	public Map(int width, int height, (int x, int y) enemySpawnPoint)
	{
		if (width <= 0 || height <= 0)
			throw new ArgumentException(message: $"{nameof(Map)}.cs: width/height cannot be <= 0.");
		else 
			_board = new object[width, height];

		// set enemyspawnpoint
		if(enemySpawnPoint.y <= 0 || enemySpawnPoint.x <= 0)
			throw new ArgumentException("Input cant be negative");
		else
			EnemySpawnPoint = enemySpawnPoint;

		// Startpoint and EnemySpawnpoint will be at the same position
		StartPoint = EnemySpawnPoint;
	}


	/// <summary>
	/// Gets a Value on the Board by the given Y and X values
	/// </summary>
	/// <param name="y"></param>
	/// <param name="x"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	public object GetBoardContents(int y, int x)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
			throw new ArgumentException("Inputs must be valid");
		else
			return _board[y, x];
	}


	/// <summary>
	/// Sets a Value to the given Y and X values
	/// </summary>
	/// <param name="y"></param>
	/// <param name="x"></param>
	/// <param name="value"></param>
	/// <exception cref="ArgumentException"></exception>
	public void SetBoardContents(int x, int y, object value)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
			throw new ArgumentException("Inputs must be valid");
		else
			_board[y, x] = value;

	}

	/// <summary>
	/// Finds the Path between the Start and Endpoint and returns it in a List
	/// </summary>
	/// <exception cref="NotImplementedException"></exception>
	public List< (int x,int y)> FindPath()
	{
		throw new NotImplementedException();
	}
}