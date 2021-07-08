using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.Interview
{
    public class RoomRobbery
    {
        public int Rob(int[] input) // [1, 3, 2, 1]
        {
            var dict = new Dictionary<int, List<int>>();
            for (var i = 0; i < input.Length; i++)
            {
                if (dict.TryGetValue(input[i], out var value))
                {
                    value.Add(i);
                    continue;
                }

                dict[input[i]] = new List<int> {i};
            }

            var arr = dict.OrderByDescending(c => c.Key); // [3, 2, 1] [1; 2; 0,3]

            var result = 0;

            var robbedRooms = new HashSet<int>();

            foreach (var keyValuePair in arr)
            {
                if (!keyValuePair.Value.Any())
                {
                    continue;
                }

                foreach (var idx in keyValuePair.Value)
                {
                    if (idx == input.Length - 1 && robbedRooms.Contains(0)) continue;
                    if (idx == 0 && robbedRooms.Contains(input.Length - 1)) continue;
                    if (robbedRooms.Contains(idx + 1) || robbedRooms.Contains(idx - 1)) continue;

                    result += keyValuePair.Key;
                    robbedRooms.Add(idx);
                }
            }

            return result;
        }
        
        public int RobEugene(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
        }


        private static int Rob(int[] nums, int start, int end)
        {
            var (current, prev) = (0, 0);

            for (int i = start; i <= end; i++)
            {
                var cur = prev + nums[i] > current ? prev + nums[i] : current;
                prev = current;
                current = cur;
            }

            return Math.Max(prev, current);
        }
    }
}