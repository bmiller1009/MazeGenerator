using System;
using System.Collections;
using System.Collections.Generic;
using MazeGenerator;

namespace MazeDriver
{
	class MainClass
	{	
		public static void Write(int idx, string[,] s)
		{	
			for(int i = 0; i < 3; i++)
				Console.Write (s[idx, i]);
		}
		
		public static void Main (string[] args)
		{
			var mg = new MazeGen(5, 5);
			
			mg.Build();

			var io = mg.Render();
			
			int k = 0, idx = 0;
			
			while(k < io.Count)
			{
				Write(idx, io[k]);
				
				k++;
				
				if(k % mg.Matrix.MAX_RIGHT == 0)
				{	
					Console.WriteLine();
					
					idx++;
					
					if(idx < 3)
						k = k - mg.Matrix.MAX_RIGHT;
					else
					{	
						idx = 0;
						k++;
					}
				}
			}
		}	
	}
}
