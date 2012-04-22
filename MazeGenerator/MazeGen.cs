using System;
using System.Collections;
using System.Collections.Generic;

namespace MazeGenerator
{
	public class MazeGen
	{	

		private Stack<Node> _nodeStack = new Stack<Node>();
		private Matrix _matrix = null;
		private int nodesVisitedCount = 0;
		
		public MazeGen (int rows, int columns)
		{		
			_matrix = new Matrix(rows, columns);
		}
		
		public Matrix Matrix
		{
			get{return _matrix;}
		}
		
		public void Build()
		{	
			//Get the node from the matrix
			var currentNode = _matrix.GetRandomNode();
			
			while(nodesVisitedCount < _matrix.NodeCount - 1)
			{	
				//Grab a neighbor node with all walls up
				var neighborNode = currentNode.GetRandomNeighborWithAllWalls();
				
				//if the neighbor comes back null, then there are no neighbors with all walls intact, so we point to the previous node
				//and continue in the loop
				if(neighborNode == null)
				{	
					if(_nodeStack.Count > 0)
						currentNode = _nodeStack.Pop();
					
					continue;
				}
				
				//if we find a neighbor with all walls up, set the node pointer of current 
				currentNode.ConnectNode(neighborNode);
				
				//Push currentNode onto the stack
				_nodeStack.Push(currentNode);
				
				//Make neighborNode the new current node
				currentNode = neighborNode;
				
				//increment visited nodes variable
				nodesVisitedCount++;
			}
		}
		
		public List<string[,]> Render()
		{
			var gridList = new List<string[,]>();
			
			for(int i = 0; i < _matrix.Rows; i++)
				for(int k = 0; k < _matrix.Cols; k++)
					gridList.Add (_matrix.GetNode (i, k).GetASCII());
			
			return gridList;	
		}
	}
}

