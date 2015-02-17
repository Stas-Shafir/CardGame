using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CardGameServer
{
    public class ServiceProxy
    {
        public static Servicegame Proxy { get; set; }
    }


    [ServiceContract]
    public interface Servicegame
    {
        [OperationContract]
        bool Login(string user, string pass);

        [OperationContract]
        bool isAccountContainsAnyCharacter(string user);

        [OperationContract]
        bool createCharacter(string user, string name, int heroCardId);

        [OperationContract]
        List<Card> getHeroesTemplateAvailableList();

        [OperationContract]
        CharInfo EnterWorld(string user);

        [OperationContract]
        List<CharInfo> getRanking();
    }
}
