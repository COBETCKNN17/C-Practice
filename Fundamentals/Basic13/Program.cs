using System;
using System.Collections.Generic;

namespace Basic13 {
    class Basic13 {
        public static void PrintTo255 () {
            for (int i = 1; i < 256; i++) {
                Console.WriteLine (i);
            }
        }

        public static void PrintOddTo255 () {
            for (int i = 1; i < 256; i++) {
                if (i % 2 == 1) {
                    Console.WriteLine (i);
                }
            }
        }

        public static void PrintSum () {
            int sum = 0;
            for (int i = 1; i < 256; i++) {
                sum += i;
                Console.WriteLine (sum);
            }
        }

        public static void PrintArray (params int[] vals) {
            foreach (var val in vals) {
                Console.WriteLine (val);
            }
        }
        public static void FindMaximum (params int[] maxNums) {
            int max = maxNums[0];
            foreach (var maxNum in maxNums) {
                if (maxNum > max) {
                    max = maxNum;
                }
            }
            Console.WriteLine ("Maximum: " + max);
        }

        public static void GetAverage (params int[] nums) {
            int sum = 0;
            foreach (var num in nums) {
                sum += num;
            }
            Console.WriteLine ("Average: " + (sum / (nums.Length)));
        }

        public static void OddArray () {
            var y = new List<int> ();
            for (int i = 1; i < 256; i++) {
                if (i % 2 == 1) {
                    y.Add (i);
                }
            }

            Console.WriteLine ("Array y: ");
            foreach (var i in y) {
                Console.Write (+i + ", ");
            }
        }


        public static void GreaterThanY (int y, params int[] compVals) {
            int count = 0;
            foreach (var compVal in compVals) {
                if (compVal > y) {
                    count++;
                }

            }
            Console.WriteLine ($"Num on Ints greater than {y}: {count}");
        }

        public static void SquareValues (params int[] x) {
            for (int i = 0; i < x.Length; i++) {
                x[i] = x[i] * x[i];
            }

            Console.Write ("Squared Values: ");
            foreach (var val in x) {
                Console.Write (val + ", ");
            }
            Console.WriteLine ("");
        }

        public static void removeNegatives (params int[] x) {
            for (int i = 0; i < x.Length; i++) {
                if (x[i] < 0) {
                    x[i] = 0;
                }
            }

            Console.WriteLine ("Array with no negs:");
            foreach (var i in x) {
                Console.Write (i + ", ");
            }
        }

        public static void MinMaxAvg (params int[] x) {
            FindMaximum (x);
            GetAverage (x);
            int min = x[0];
            for (int i = 1; i < x.Length; i++) {
                if (x[i] < min) {
                    min = x[i];
                }
            }
            Console.WriteLine ("min: " + min);
        }

        public static void ShiftArray (List<int> newList) {
            newList.RemoveAt (0);
            newList.Add (0);
            Console.Write ("[ ");
            foreach (var item in newList) {
                Console.Write (item + ", ");
            }
            Console.WriteLine ("]");
        }

        public static void NumberToString (List<object> xList) {
            for (int i = 0; i < xList.Count; i++) {
                if ((int) xList[i] < 0) {
                    xList[i] = "Dojo";
                }
            }
            foreach (var item in xList) {
                Console.Write (item);
            }

            Console.WriteLine ();
        }
        static void Main (string[] args) {
            //Basic13.PrintTo255();
            Basic13.PrintOddTo255 ();
        }
    }
}