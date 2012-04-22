
using System;
using System.Collections;
using System.Collections.Generic;

namespace MazeGenerator
{
	public class Node
	{		
		private Random _rand = new Random();
		private int _row = 0;
		private int _col = 0;
		
		public Node (int row, int col)
		{
			_row = row;
			_col = col;
		}
		
		public int Row
		{
			get{return _row;}
		}
		
		public int Col
		{
			get{return _col;}
		}
		
		public Node NorthNode
		{
			get;
			set;
		}
		
		public Node SouthNode
		{
			get;
			set;
		}
		
		public Node EastNode
		{
			get;
			set;
		}
		
		public Node WestNode
		{
			get;
			set;
		}
		
		public bool NorthNodeConnected
		{
			get;
			set;
		}
		
		public bool SouthNodeConnected
		{
			get;
			set;
		}
		
		public bool EastNodeConnected
		{
			get;
			set;
		}
		
		public bool WestNodeConnected
		{
			get;
			set;
		}
		
		public bool Visited
		{
			get;
			set;
		}
		
		public bool AllWallsIntact
		{
			get
			{
				return !NorthNodeConnected && !SouthNodeConnected && !EastNodeConnected & !WestNodeConnected;
			}
		}
		
		public Node GetRandomNode()
		{
			int pos = _rand.Next(0, 3);
			
			switch(pos)
			{
				case 0: 
					return this.NorthNode;
				case 1:
					return this.SouthNode;
				case 2:
					return this.EastNode;
				case 3:
					return this.WestNode;
			}
			
			throw new Exception("Wall not found");
		}
		
		public Node GetRandomNeighborWithAllWalls()
		{
			var nodeList = new List<Node>();
			
			if(this.NorthNode != null && this.NorthNode.AllWallsIntact)
				nodeList.Add(this.NorthNode);
			if(this.SouthNode != null && this.SouthNode.AllWallsIntact)
				nodeList.Add(this.SouthNode);
			if(this.EastNode != null && this.EastNode.AllWallsIntact)
				nodeList.Add(this.EastNode);
			if(this.WestNode != null && this.WestNode.AllWallsIntact)
				nodeList.Add(this.WestNode);
			
			if(nodeList.Count == 0)
				return null;
			
			Shuffle(nodeList);
			
			return nodeList[0];
		}
		
		public void ConnectNode(Node node)
		{
			if(this.NorthNode != null && node.GetHashCode() == this.NorthNode.GetHashCode())
			{
				this.NorthNodeConnected = true;
				node.SouthNodeConnected = true;
			}
			else if(this.SouthNode != null && node.GetHashCode() == this.SouthNode.GetHashCode())
			{
				this.SouthNodeConnected = true;
				node.NorthNodeConnected = true;
			}
			else if(this.EastNode != null && node.GetHashCode() == this.EastNode.GetHashCode())
			{
				this.EastNodeConnected = true;
				node.WestNodeConnected = true;
			}
			else if(this.WestNode != null && node.GetHashCode() == this.WestNode.GetHashCode())
			{
				this.WestNodeConnected = true;
				node.EastNodeConnected = true;
			}
		}
		
		public override int GetHashCode ()
		{
			return _col ^ _row;
		}
		
		public void Shuffle<T>(IList<T> list)  
		{  
		    var rng = new Random();  
		    int n = list.Count;  
			
		    while (n > 1)
			{  
		        n--;  
		        int k = rng.Next(n + 1);  
		        T value = list[k];  
		        list[k] = list[n];  
		        list[n] = value;  
    		}  
		}
		
		public String[,] GetASCII()
		{
			var stringArray = new String[3,3];
			
			stringArray[0, 0] = "*";
			stringArray[0, 1] = (!this.NorthNodeConnected) ? "*" : " ";
			stringArray[0, 2] = "*";
			stringArray[1, 0] = (!this.WestNodeConnected) ? "*" : " ";
			stringArray[1, 1] = " ";
			stringArray[1, 2] = (!this.EastNodeConnected) ? "*" : " ";
			stringArray[2, 0] = "*";
			stringArray[2, 1] = (!this.SouthNodeConnected) ? "*" : " ";
			stringArray[2, 2] = "*";
			
			return stringArray;
		}
	}
}

