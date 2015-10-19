using System;
using System.Collections;
using System.Collections.Generic;

namespace assignment4
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// TODO: Create initial checks for arguments
			// if(args.Length == 0) return;
			ASCIIBox box = new ASCIIBox("A", 1,2,3,4);
			Console.WriteLine(box.Art);

			List<String> exampleList = new List<String>();
			// Example that finds the first element with string length 0
			exampleList.Find(i => i.Length == 0);

		}
	}
}
>>>>>>> Stash
