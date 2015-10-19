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

			List<Job> schedule = new List<Job> ();

			Job jobA;
			Job jobB;
			Job jobC;
			Job jobD;
			Job jobE;
			Job jobF;
			Job jobG;
			Job jobH;
			Job jobI;
			Job jobJ;
			Job jobK;
			Job jobL;

			jobA = new Job ("A", 2, new List<Job>(){}, new List<Job>(){});
			jobB = new Job ("B", 3, new List<Job>(){}, new List<Job>(){});
			jobC = new Job ("C", 2, new List<Job>(){}, new List<Job>(){});
			jobD = new Job ("D", 3, new List<Job>(){}, new List<Job>(){});
			jobE = new Job ("E", 2, new List<Job>(){}, new List<Job>(){});
			jobF = new Job ("F", 1, new List<Job>(){}, new List<Job>(){});
			jobG = new Job ("G", 4, new List<Job>(){}, new List<Job>(){});
			jobH = new Job ("H", 5, new List<Job>(){}, new List<Job>(){});
			jobI = new Job ("I", 3, new List<Job>(){}, new List<Job>(){});
			jobJ = new Job ("J", 3, new List<Job>(){}, new List<Job>(){});
			jobK = new Job ("K", 2, new List<Job>(){}, new List<Job>(){});
			jobL = new Job ("L", 2, new List<Job>(){}, new List<Job>(){});


			// A
			jobA.setSuccessors (new List<Job>(){jobD});
			jobA.setPredecessors (new List<Job>(){});
			schedule.Add(jobA);

			// B
			jobB.setSuccessors (new List<Job>(){jobE,jobF});
			jobB.setPredecessors (new List<Job>(){});
			schedule.Add(jobB);

			// C
			jobC.setSuccessors (new List<Job>(){jobE,jobH});
			jobC.setPredecessors (new List<Job>(){});
			schedule.Add(jobC);

			// D
			jobD.setSuccessors (new List<Job>(){jobI});
			jobD.setPredecessors (new List<Job>(){jobA});
			schedule.Add(jobD);

			// E
			jobE.setSuccessors (new List<Job>(){jobJ});
			jobE.setPredecessors (new List<Job>(){jobB,jobC});
			schedule.Add(jobE);

			// F
			jobF.setSuccessors (new List<Job>(){jobI});
			jobF.setPredecessors (new List<Job>(){jobA,jobB});
			schedule.Add(jobF);

			// G
			jobG.setSuccessors (new List<Job>(){jobJ});
			jobG.setPredecessors (new List<Job>(){jobA});
			schedule.Add(jobG);

			// H
			jobH.setSuccessors (new List<Job>(){});
			jobH.setPredecessors (new List<Job>(){jobC});
			schedule.Add(jobH);

			// I
			jobI.setSuccessors (new List<Job>(){jobK});
			jobI.setPredecessors (new List<Job>(){jobD,jobF});
			schedule.Add(jobI);

			// J
			jobJ.setSuccessors (new List<Job>(){});
			jobJ.setPredecessors (new List<Job>(){jobE,jobG});
			schedule.Add(jobJ);

			// K
			jobK.setSuccessors (new List<Job>(){jobL});
			jobK.setPredecessors (new List<Job>(){jobI});
			schedule.Add(jobK);

			// L
			jobL.setSuccessors (new List<Job>(){});
			jobL.setPredecessors (new List<Job>(){jobK});
			schedule.Add(jobL);

			PDEalgorithm pde = new PDEalgorithm (schedule);
		}
	}
}