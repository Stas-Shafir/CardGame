﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CardGameServer
{
    [DataContract]
    public class CharInfo
    {
        [DataMember]
        public string nickname { get; set; }

        [DataMember]
        public string heroname { get; set; }

        [DataMember]
        public int character_level { get; set; }

        [DataMember]
        public int exp { get; set; }

        [DataMember]
        public int games { get; set; }

        [DataMember]
        public int wins { get; set; }

        [DataMember]
        public int score { get; set; }
    }
}
