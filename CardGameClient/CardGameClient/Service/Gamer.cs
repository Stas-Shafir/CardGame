using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CardGameServer
{
    [DataContract]
    public class Gamer
    {
        [DataMember]
        public string nick { get; set; }

        [DataMember]
        public int level { get; set; }
    }
}
