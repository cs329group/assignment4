using System;
using System.Text;
using System.Reflection;


namespace assignment4
{
    public struct Bounds{
        public bool useLeftBound;
        public bool useRightBound; 
        public int leftBound;
        public int rightBound;

        public Bounds(bool l, bool r, int lb, int rb){
            useLeftBound = l;
            useRightBound = r;
            leftBound = lb;
            rightBound = rb;
        }
    }

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

        // TODO: Rewrite all of these to handle at least 3 digits.
        // TODO: Do some work with the gets. Currenly they're useless and only help with compiler issues.

		public int EarlyStart {
			get{
				return EarlyStart;
			}
			set{
                Bounds b = new Bounds(true, false, EARLYSTARTINDEX - 1, 0);
                asciiHelper(EARLYSTARTINDEX, value, b);
			}
		}

		public int EarlyFinish {
			get{
				return EarlyFinish;
			}
			set{
                Bounds b = new Bounds(false, true,  0, EARLYFINISHINDEX+1);
                asciiHelper(EARLYFINISHINDEX, value, b);
            }
		}

		public int LateStart {
			get{
				return LateStart;
			}
			set{
                Bounds b = new Bounds(true, false, LATESTARTINDEX - 1, 0);
                asciiHelper(LATESTARTINDEX, value, b);

			}
		}

		public int LateFinish {
			get{
				return LateFinish;
			}
			set{
                Bounds b = new Bounds(false, true,  0, LATEFINISHINDEX+1);
                asciiHelper(LATEFINISHINDEX, value, b);
			}
		}

        public String TaskID {
            get{
                return TaskID;
            }
            set{
                // TODO: Make this work so that it simply uses a string
                StringBuilder builder = new StringBuilder(Art);
                setString(value, TASKIDINDEX, 0, builder);
                Art = builder.ToString();
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
        private void asciiHelper(int index, int value, Bounds bounds){
            StringBuilder builder = new StringBuilder(Art);

            // 1 digit, take care of it quick. Also argument check
            String str = value.ToString();

            if (value < 0)
                throw new ArgumentOutOfRangeException();
            else if (str.Length == 1)
            {
                builder[index] = charHelper(value);
                goto SetArt;
            }

            int startingSpot = -1, endingSpot = -1;

            // We're not going to account for super long numbers. We can do that... never
            if (bounds.useLeftBound)
            {
                startingSpot = bounds.leftBound;
            }
            else if (bounds.useRightBound)
            {
                endingSpot = bounds.rightBound;
                startingSpot = endingSpot - str.Length;
            }
            else
                startingSpot = index;

            setString(str, startingSpot, endingSpot, builder);

            SetArt:
            Art = builder.ToString();
        }

        private char charHelper(int toConvert){
            return (char) (toConvert + 48);
        }

        private void setString(String str, int start, int end,  StringBuilder builder){
            int startingPoint = start;
            for (int i = 0; i < str.Length; i++)
            {
                builder[startingPoint] = str[i];
                startingPoint++;
            }
        }
       
	}
}

