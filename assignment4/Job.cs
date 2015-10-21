using System;
using System.Collections;
using System.Collections.Generic;

namespace assignment4
{
	public class Job
	{
		public string name { get; set; }
		public int duration { get; set; }
		public List<Job> predecessors { get; set; }
		public List<Job> successors { get; set; }
		public int earlyStart { get; set; }
		public int earlyEnd { get; set; }
		public int lateStart { get; set; }
		public int lateEnd { get; set; }
		public bool criticalPath { get; set; }

		public Job(string name, int duration, List<Job> predecessors, List<Job> successors)
		{
			this.name = name;
			this.duration = duration;
			this.predecessors = predecessors;
			this.successors = predecessors;
			this.criticalPath = false;
		}

		public void setSuccessors(List<Job> successors){
			this.successors = successors;
		}

		public void setPredecessors(List<Job> predecessors){
			this.predecessors = predecessors;
		}
	}
}

