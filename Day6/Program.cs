using System;

namespace Day6
{
    class MatchOutput
    {
        public bool isMatched;
        public int matchedNum;
        public string msg;
        public int maxDepth;
    }
    class Program
    {

        static MatchOutput match(string source)
        {

            MatchOutput output = new MatchOutput();

            int unclosed = 0;
            int count = 0;
            int depth = 0;
            foreach (var ch in source)
            {
                if (ch == '{') unclosed++;
                else if (ch == '}') 
                {
                    unclosed--;
                    count++;
                }
                if (unclosed < 0)
                {
                    count--;
                    output.isMatched = false;
                    output.matchedNum = count;
                    output.msg = "there's an extra }";
                    return output;
                }
                if (unclosed > depth)
                {
                    depth++;
                }

            }
            if (unclosed == 0)
            {
                output.isMatched = true;
                output.msg = "All is matched number";

            }
            else
            {
                output.isMatched = false;
                output.msg = "Not matched number";
            }
            output.matchedNum = count;
            output.maxDepth = depth;
            return output;




        }
        /*        static bool match (string source,char start='#',char end='#')
                {
                    int i = 0;
                    int unclosed = 0;
                    foreach(var ch in source)
                    {
                        if (ch == start) unclosed++;
                        else if (ch == end) unclosed--;
                        if (unclosed < 0) return false;

                    }
                    return unclosed == 0;

                    *//*            if (start == end)
                                {
                                    if (unclosed == 0 || unclosed % 2 == 0)
                                    {
                                        return true;
                                    }
                                    else return false;
                                }
                                else
                                {
                                    return unclosed == 0;
                                }*//*




                }*/
        static void Main(string[] args)
        {

            MatchOutput result = match("{{{}}}{}{}");
            Console.WriteLine("the string curly brackets is: {0} with {1} brackets, {2} with max depth of {3} ",result.isMatched?"matched":"not matched",result.matchedNum,result.msg,result.maxDepth);
        }
    }
}
