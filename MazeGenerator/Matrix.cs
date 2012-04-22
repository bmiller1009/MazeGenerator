using System;

namespace MazeGenerator
{
	public class Matrix
	{
		private Node[,] _matrix = null;
		
		public const int MAX_TOP = 0;
		public readonly int MAX_BOTTOM;
		public const int MAX_LEFT = 0;
		public readonly int MAX_RIGHT;
		
		private int _rows = 0;
		private int _cols = 0;
		
		private static Random _rand = new Random();
		
		public int Rows
		{
			get{return _rows;}
		}
		
		public int Cols
		{
			get{return _cols;}
		}
		
		public Matrix (int rows, int columns)
		{
				_rows = rows;
				_cols = columns;
			
				MAX_BOTTOM = rows - 1;
				MAX_RIGHT = columns - 1;
					
				_matrix = new Node[rows, columns];
				
				for(int i = 0; i < rows; i++)
					for(int k = 0; k < columns; k++)
						_matrix[i, k] = new Node(i, k);
			
				LoadMatrix(rows, columns);
		}
		
		private void LoadMatrix(int rows, int columns)
		{	
			for(int i = 0; i < rows; i++)
					for(int k = 0; k < columns; k++)
						AttachNeighborNodes(_matrix[i, k]);
		}
		
		public int NodeCount
		{
			get{return _rows * _cols;}
		}
		
		public Node GetNode(int row, int col)
		{
			return _matrix[row, col];
		}
		
		public Node GetRandomNode()
		{	
			return GetNode(_rand.Next(0, MAX_BOTTOM), _rand.Next(0, MAX_RIGHT));
		}
		
		private Node AttachNeighborNodes(Node node)
		{	
			int leftIndex = node.Col - 1;
			int rightIndex = node.Col + 1;
			int topIndex = node.Row - 1;
			int bottomIndex = node.Row + 1;
			
			if(leftIndex >= 0)
				node.WestNode = _matrix[node.Row, leftIndex];
			else
				node.WestNode = null;
			
			if(rightIndex <= MAX_RIGHT)
				node.EastNode = _matrix[node.Row, rightIndex];
			else
				node.EastNode = null;
			
			if(topIndex >=0)
				node.NorthNode = _matrix[topIndex, node.Col];
			else
				node.NorthNode = null;
			
		 	if(bottomIndex <= MAX_BOTTOM)
				node.SouthNode = _matrix[bottomIndex, node.Col];
			else
				node.SouthNode = null;
			
			return node;
		}
	}
}

