using System;
using System.Collections.Generic;

namespace CoreSolution
{
    public class ClassLib
    {
        public int GetMaximumPairOfSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            int maximumNumberOfPairs = 0;
            List<int> clean = new List<int>(new int[51]);
            List<int> dirty = new List<int>(new int[51]);
            foreach (int cleanSocks in cleanPile)
            {
                clean[cleanSocks]++;
            }
            foreach (int dirtySocks in dirtyPile)
            {
                dirty[dirtySocks]++;
            }
            Console.WriteLine(clean);

            for (int i = 1; i < 51; ++i)
            {
                maximumNumberOfPairs += clean[i] / 2;
                if (clean[i] % 2 != 0 && noOfWashes > 0 && dirty[i] > 0)
                {
                    maximumNumberOfPairs++;
                    noOfWashes--;
                    dirty[i]--;
                }
            }

            for (int i = 1; noOfWashes > 1 && i < 51; ++i)
            {
                if (dirty[i] >= 2)
                {
                    dirty[i] = Math.Min(dirty[i] / 2, noOfWashes / 2);
                    maximumNumberOfPairs += dirty[i];
                    noOfWashes -= 2 * dirty[i];
                }
            }
            return maximumNumberOfPairs;

        }
    }

}
