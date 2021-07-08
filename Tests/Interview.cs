using NUnit.Framework;
using Questions.Interview;

namespace Tests
{
    public class Interview
    {
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sollicitudin arcu dolor, in efficitur nisi tincidunt vel.", 20, ExpectedResult = new[]
        {
            "Lorem ipsum<1/9>",
            "dolor sit amet,<2/9>",
            "consectetur<3/9>",
            "adipiscing<4/9>",
            "elit. Phasellus<5/9>",
            "sollicitudin<6/9>",
            "arcu dolor, in<7/9>",
            "efficitur nisi<8/9>",
            "tincidunt vel.<9/9>"
        })]
        public string[] SplitSms(string text, int limit)
        {
            var alg = new SplitSms();

            var result =  alg.Split(text, limit);

            return result;
        }
        
        [TestCase(new[] {1, 3, 2, 1}, ExpectedResult = 4)]
        [TestCase(new[] {20, 3, 2, 1, 5, 20}, ExpectedResult = 27)]
        public int Test(int[] input)
        {
            var rob = new RoomRobbery();
            return rob.Rob(input);
        }
    }
}