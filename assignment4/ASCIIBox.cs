using System;
using System.Text;
using System.Reflection;


namespace assignment4
{
	/**
	 * This class is what creates the ASCII art for our PDM chart.
	 * For the ASCII art, we replace the 
	 */
	public class ASCIIBox
	{
		/**
		 * Our initial box we use when creating the ASCIIBox object.
		 * The index values for the locations in the boxes are also
		 * given. 2 or 3 digit times will have to be handled in functions.
		 */
		#region constantsRegion
		
        private const String INITIALBOX = 
			"+---+-------------+---+\n"+
			"|   |             |   |\n"+
			"+---+             +---+\n"+
			"|                     |\n"+
			"|                     |\n"+
			"|                     |\n"+
			"+---+             +---+\n"+
			"|   |             |   |\n"+
			"+---+-------------+---+\n";
		private const int EARLYSTARTINDEX = 26;
		private const int EARLYFINISHINDEX = 44;
		private const int LATESTARTINDEX = 170;
		private const int LATEFINISHINDEX = 188;
        private const int TASKIDINDEX = 107;
		#endregion

		/**
		 * The actual ascii box and its properties that will be used in the ASCII generator.
		 * There is no public set function, only a get function. Makes sure 
		 * that only changes made will be in this object's functions.
		 */
        #region properties
		public string Art { get; set; }

		// TODO: Maybe rewrite this to have a helper function handle it, only difference would be index given
        // TODO: Rewrite all of these to handle at least 3 digits.
        // TODO: Do some work with the gets. Currenly they're useless and only help with compiler issues.

		public int EarlyStart {
			get{
				return EarlyStart;
			}
			set{
                asciiHelper(EARLYSTARTINDEX, (char)(value + 48));
			}
		}

		public int EarlyFinish {
			get{
				return EarlyFinish;
			}
			set{
                asciiHelper(EARLYFINISHINDEX, (char)(value + 48));
            }
		}

		public int LateStart {
			get{
				return LateStart;
			}
			set{
                asciiHelper(LATESTARTINDEX, (char)(value + 48));

			}
		}

		public int LateFinish {
			get{
				return LateFinish;
			}
			set{
                asciiHelper(LATEFINISHINDEX, (char)(value + 48));
			}
		}

        public String TaskID {
            get{
                return TaskID;
            }
            set{
                asciiHelper(TASKIDINDEX, value[0]);
            }
        }
        #endregion

		public ASCIIBox (String taskID, int earlyStart, int earlyFinish, int lateStart, int lateFinish)
		{
			Art = INITIALBOX;
            TaskID = taskID;
			EarlyStart = earlyStart;
			EarlyFinish = earlyFinish;
			LateStart = lateStart;
			LateFinish = lateFinish;
		}
        /**
         * Returns a string that the properties use as a helper function.
         * Mainly to avoid a bunch of copying and pasting of code
         */
        private void asciiHelper(int index, char character){
            // TODO: Make it handle 3 digits
            StringBuilder builder = new StringBuilder(Art);
            builder [index] = character;
            Art = builder.ToString();
        }
	}
}

