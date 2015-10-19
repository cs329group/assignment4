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
			this.schedule = schedule;
			int scheduleEnd = fillEarliest (schedule);
			fillLatest (schedule, scheduleEnd);
			foreach (Job job in schedule) {
				Console.Write ("Name:" + job.name + "   Duration:" + job.duration + "   ES:" + job.earlyStart + "   EE:" + job.earlyEnd + "   LS:" + job.lateStart + "   LS:" + job.lateEnd+"\n");
			}
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
					int minLatestStart = 0;
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
	}
}

