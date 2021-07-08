using System.Collections.Generic;
using System.Linq;

namespace Questions.Interview
{
    public class RoomRobbery
    {
        public int Rob(int[] input)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < input.Length; i++)
            {
                if (dict.TryGetValue(input[i], out var value))
                {
                    value.Add(i);
                    continue;
                }

                dict[i] = new List<int>() {i};
            }

            var arr = dict.OrderBy(c => c.Key);

            var result = 0;

            var lastIdx = -1;

            foreach (var keyValuePair in arr)
            {
                if (keyValuePair.Value.Contains(lastIdx + 1) || keyValuePair.Value.Contains(lastIdx  - 1))
                {
                    continue;
                }

                result += keyValuePair.Key;
                lastIdx = keyValuePair.Value[0];
                keyValuePair.Value.RemoveAt(0);
            }

            return result;
        }
    }
}