using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace assignment4
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<Job> jobs = new List<Job> ();
			List<String[]> jobDependancies = new List<String[]> ();
			//Read file input
			try{
				using(StreamReader sr = new StreamReader(args[0])){
					String line;
					char[] delimiterChars = {' '};
					char[] delimiterDepend = {','};
					//Console.WriteLine("1");
					while((line = sr.ReadLine()) != null){
						string[] words = line.Split(delimiterChars);
						int dur;
						if(!Int32.TryParse(words[1], out dur)){
							Console.WriteLine("Duration value could not be parsed to an int. Defaulting to 1");
							dur = 1;
						}
						//Console.WriteLine("2");
						//Parse dependancies
						jobs.Add(new Job(words[0], dur, new List<Job>(), new List<Job>()));

						if(words.Length > 2){
							string[] depends = words[2].Split(delimiterDepend);
							jobDependancies.Add(depends);
						}else{
							string[] depends = {};
							jobDependancies.Add(depends);
						}

					}
					//Console.WriteLine("last");

					//add predecessors and sucessors
					for(int i = 0; i < jobs.Count; i++){
						Job curJob = jobs[i];
						for(int j = 0; j < jobDependancies[i].Length; j++){

							//look through jobs to add to list
							for(int k = 0; k < jobs.Count; k++){
								Job other = jobs[k];
								if(other.name.Equals(jobDependancies[i][j])){
									curJob.predecessors.Add(other);
									other.successors.Add(curJob);
								}
							}

						}
					}


					//printJobs(jobs);

				}
			}catch(Exception e){
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}


			//ASCIIBox box = new ASCIIBox("A", 1,2,3,4);
			//Console.WriteLine(box.Art);
			//var Testing = new Testing ();
			//List<Job> schedule = Testing.sampleSchedule ();
			PDEalgorithm pde = new PDEalgorithm (jobs);
		}

		public static void printJobs(List<Job> jobs){
			for(int i = 0; i < jobs.Count; i++){
				Job job = jobs[i];

				Console.Write("Name: " + job.name + " | duration: " + job.duration + "\n    Predecessors: ");
				for(int j = 0; j < job.predecessors.Count; j++){
					Console.Write(job.predecessors[j].name + " ");
				}
				Console.Write("\n    Sucessors: ");
				for(int j = 0; j < job.successors.Count; j++){
					Console.Write(job.successors[j].name + " ");
				}
				Console.Write("\n");
			}
		}
	}
}