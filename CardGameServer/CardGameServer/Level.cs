using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGameServer
{
    public class Level
    {
        public static Dictionary<int, int> Levels = new Dictionary<int, int>();

        static Level()
        {
            Levels.Add(1, 0);
            Levels.Add(2, 245);
            Levels.Add(3, 863);
            Levels.Add(4, 1256);
            Levels.Add(5, 1965);
            Levels.Add(6, 2679);
            Levels.Add(7, 3278);
            Levels.Add(8, 4267);
            Levels.Add(9, 5456);
            Levels.Add(10, 6896);
            Levels.Add(11, 8456);
            Levels.Add(12, 10234);
            Levels.Add(13, 13456);
            Levels.Add(14, 16536);
            Levels.Add(15, 19456);
            Levels.Add(16, 24567);
            Levels.Add(17, 30654);
            Levels.Add(18, 37556);
            Levels.Add(19, 47567);
            Levels.Add(20, 60000);
        }
    }
}
