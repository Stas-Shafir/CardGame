using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CardGameClient
{
    public class Rarity
    {
        public string RarityName { get; set; }
        public Brush RarityColor { get; set; }

        public Rarity()
        {
        }

        public Rarity(string rn, Brush rc)
        {
            RarityName = rn;
            RarityColor = rc;
        }


    }
}
