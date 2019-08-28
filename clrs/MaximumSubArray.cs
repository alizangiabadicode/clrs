using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clrs
{
    // using divide and conquer
    class MaximumSubArray
    {
        public Maximum MaximumCrossingSubArray(int[] array, int low,int mid, int high)
        {
            int leftSum = int.MinValue;
            int maxLeft = mid;
            int sum = 0;

            // maximum left sub array
            for (int i = mid; i >= low; i--)
            {
                sum += array[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            int rightSum = int.MinValue;
            int maxRight = mid + 1;
            sum = 0;

            // maximum right sub array
            for (int i = mid + 1; i <= high; i++)
            {
                sum += array[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return new Maximum()
            {
                MaximumCrossing = leftSum + rightSum,
                MaximumLeft = maxLeft,
                MaximumRight = maxRight
            };
        }

        public Maximum FindMaximumSubArray(int[] array, int low, int high)
        {
            if (low == high)
            {
                return new Maximum()
                {
                    MaximumCrossing = array[low],
                    MaximumLeft = low,
                    MaximumRight = high
                };
            }
            else
            {
                var mid = (low + high) / 2;
                var leftMaximum = FindMaximumSubArray(array, low, mid);
                var rightMaximum = FindMaximumSubArray(array, mid + 1, high);
                var crossingMaximum = MaximumCrossingSubArray(array, low, mid, high);
                if (leftMaximum.MaximumCrossing > rightMaximum.MaximumCrossing &&
                    leftMaximum.MaximumCrossing > crossingMaximum.MaximumCrossing)
                {
                    return leftMaximum;
                }
                else if (rightMaximum.MaximumCrossing > leftMaximum.MaximumCrossing &&
                         rightMaximum.MaximumCrossing > crossingMaximum.MaximumCrossing)
                {
                    return rightMaximum;
                }
                else
                {
                    return crossingMaximum;
                }
            }
        }
    }

    class Maximum
    {
        public int MaximumRight { get; set; }
        public int MaximumLeft { get; set; }
        public int MaximumCrossing { get; set; }
    }

    class Program
    {
        static void Main()
        {
            int[] numbers = {1, 3, -3, 1, 6, -2, 1};
            MaximumSubArray msa = new MaximumSubArray();
            var maximum = msa.FindMaximumSubArray(numbers, 0, numbers.Length - 1);
            Console.WriteLine(maximum.MaximumCrossing);
            Console.ReadKey();
        }
    }
}

