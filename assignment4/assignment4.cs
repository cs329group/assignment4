using System;
using System.Collections;
using System.Collections.Generic;

namespace assignment4
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//ASCIIBox box = new ASCIIBox("A", 1,2,3,4);
			//Console.WriteLine(box.Art);
			var Testing = new Testing ();
			List<Job> schedule = Testing.sampleSchedule ();
			PDEalgorithm pde = new PDEalgorithm (schedule);
		}
	}
}