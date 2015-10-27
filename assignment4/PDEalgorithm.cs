using System;
using System.Collections;
using System.Collections.Generic;
namespace assignment4
{
	public class PDEalgorithm
	{
		List<Job> schedule;
		public PDEalgorithm (List<Job> schedule)
		{
			generateSchedule(schedule);
		}
		public void generateSchedule(List<Job> schedule){
			this.schedule = schedule;
			int scheduleEnd = fillEarliest (schedule);
			fillLatest (schedule, scheduleEnd);
			foreach (Job job in schedule) {
				ASCIIBox box = new ASCIIBox(job.name, job.earlyStart,job.earlyEnd,job.lateStart,job.lateEnd);
				Console.WriteLine(box.Art);
			}
			findCriticalPath (schedule);
		}

		public int fillEarliest(List<Job> schedule)
		{
			int scheduleEnd = 0;
			Queue<Job> jobQueue = new Queue<Job> ();

			// push all jobs that are at the beginning (no predecessors)
			foreach (Job job in schedule) {
				if (job.predecessors.Count == 0) {
					jobQueue.Enqueue (job);
				}
			}

			// BFS through job schedule
			while (jobQueue.Count != 0) {
				Job curJob = jobQueue.Dequeue ();
				// Console.Write ("1\n");
				// the job is at the begninning of the schedule
				if (curJob.predecessors.Count == 0) {
					curJob.earlyStart = 0;
				} else {
					int maxEarliestEning = 0;
					// find the predecessor with the greatest earliest ending, which will serve as the curJob's earliest start
					foreach (Job prevJob in curJob.predecessors) {
						if (prevJob.earlyEnd> maxEarliestEning) {
							maxEarliestEning = prevJob.earlyEnd;
						}
					}
					curJob.earlyStart = maxEarliestEning;
				}

				curJob.earlyEnd = curJob.earlyStart + curJob.duration;
				if (scheduleEnd < curJob.earlyEnd) {
					scheduleEnd = curJob.earlyEnd;
				}

				// push the curjob's successors onto the stack
				// Console.Write ("Name: " + curJob.name + " successors count: " + curJob.successors.Count + "\n");
				foreach (Job nextJob in curJob.successors) {
					// Console.Write ("curJob: " + curJob.name + " succ: " + nextJob.name + "\n");
					jobQueue.Enqueue (nextJob);
				}
			}
			return scheduleEnd;
		}

		public void fillLatest(List<Job> schedule, int scheduleEnd){
			Queue<Job> jobQueue = new Queue<Job> ();

			// push all jobs that are at the beginning (no predecessors)
			foreach (Job job in schedule) {
				if (job.successors.Count == 0) {
					jobQueue.Enqueue (job);
				}
			}

			// BFS through job schedule
			while (jobQueue.Count != 0) {
				Job curJob = jobQueue.Dequeue ();

				// the job is at the end of the schedule
				if (curJob.successors.Count == 0) {
					curJob.lateEnd = scheduleEnd;
				} else {
					int minLatestStart = int.MaxValue;
					// find the successor with the smallest latest start, which will serve as the curJob's latest end
					foreach (Job nextJob in curJob.successors) {
						if (nextJob.lateStart < minLatestStart) {
							minLatestStart = nextJob.lateStart;
						}
					}

					curJob.lateEnd = minLatestStart;
				}

				// push the curjob's successors onto the stack
				foreach (Job prevJob in curJob.predecessors) {
					jobQueue.Enqueue (prevJob);
				}
				curJob.lateStart = curJob.lateEnd - curJob.duration;
			}
		}

		public List<List<Job>> findCriticalPath(List<Job> schedule){
			Stack<Job> criticalPathStack = new Stack<Job> ();
			// if ES=LS and EE=LE the job will be on the critical path
			foreach (Job job in schedule) {
				
				if (partOfCriticalPath(job)) {
					job.criticalPath = true;

					// if this job is at the beginning we need to preload it into the stack
					if (job.predecessors.Count == 0) {
						criticalPathStack.Push (job);
					}
				}
			}
			List<List<Job>> criticalPathList = new List<List<Job>>();
			int listID = 0;
			List<Job> currentCriticalPathList = new List<Job>();
			while (criticalPathStack.Count != 0) {
				Job curJob = criticalPathStack.Pop ();
				currentCriticalPathList.Add (curJob);

				//check if successors are part of critical path
				foreach (Job nextJob in curJob.successors) {
					if (partOfCriticalPath (nextJob)) {
						criticalPathStack.Push (nextJob);
					}
				}

				//check if were at the end of the list, if we are add the current critical path to the overall critical path list
				if (curJob.successors.Count == 0) {
					if (currentCriticalPathList [0].predecessors.Count == 0) {
						if (currentCriticalPathList[currentCriticalPathList.Count-1].successors.Count == 0) {
							List<Job> copy = new List<Job>(currentCriticalPathList);
							criticalPathList.Insert (listID, copy);
							listID = listID + 1;
						}
					}
					currentCriticalPathList.Clear ();
				}
			}
			Console.Write ("Critical Path: ");
			foreach (List<Job> joblist in criticalPathList) {
				foreach (Job job in joblist) {
					Console.Write (job.name + ", ");
				}
				Console.Write ("\n");
			}

			return criticalPathList;
		}

		// This is really bad, but the && operator wasnt working, idk why
		private bool partOfCriticalPath(Job job){
			if (job.earlyEnd == job.lateEnd) {
				if (job.earlyStart == job.lateStart) {
					return true;
				} else {
					return false;
				}
			}
			else{
				return false;
			}
		}
	}
}

