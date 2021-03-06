using System.Collections.Generic;
namespace Questions.Interview
{
    public class SplitSms
    {
        //Similar to https://leetcode.com/problems/text-justification/

        // Implement a method string[] split(string text, int limit)
        // Where text is a long sms and it needs to be divided to Y messages.
        // Each message must contain<x/y> suffix where x is the current message and y is total.

        // Example:
        // Input:
        // text = Lorem ipsum dolor sit amet, consectetur adipiscing elit.Phasellus sollicitudin arcu dolor, in efficitur nisi tincidunt vel.
        // limit = 20
        // Output:
        // [
        //   "Lorem ipsum<1/9>",
        //   "dolor sit amet,<2/9>",
        //   "consectetur<3/9>",
        //   "adipiscing<4/9>",
        //   "elit. Phasellus<5/9>",
        //   "sollicitudin<6/9>",
        //   "arcu dolor, in<7/9>",
        //   "efficitur nisi<8/9>",
        //   "tincidunt vel.<9/9>",
        // ]
        public string[] Split(string text, int limit)
        {
            var maxSmsCount = text.Split(' ').Length;
            var result = new List<string>();
            var currentSms = 1;
            var maxSms = 1;
            var lastSpaceIndex = 0;
            var smsStart = 0;
            var currentLimit = limit;

            int getSuffixLength() => currentSms.ToString().Length + maxSms.ToString().Length + 3;

            for (var i = 0; i < text.Length; i++)
            {
                var currentCh = text[i];
                if (currentCh == ' ' && i < getSuffixLength() + currentLimit)
                {
                    lastSpaceIndex = i;
                } else if (i >= currentLimit - getSuffixLength())
                {
                    result.Add(text.Substring(smsStart, lastSpaceIndex) + $"<{currentSms++}/{maxSms++}>");

                    i = lastSpaceIndex + 1;
                    currentLimit += i;
                    smsStart = i;

                }
            }

            return result.ToArray();
        }
    }
}