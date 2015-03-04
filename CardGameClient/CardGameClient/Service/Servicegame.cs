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
        int Login(string user, string pass);

        [OperationContract]
        bool isAccountContainsAnyCharacter(string user);

        [OperationContract]
        bool createCharacter(string user, string name, int heroCardId);

        [OperationContract]
        List<Card> getHeroesTemplateAvailableList();

        [OperationContract]
        CharInfo EnterWorld(string user);

        [OperationContract]
        void iAmOnline(string user);

        [OperationContract]
        List<CharInfo> getRanking();

        [OperationContract]
        Game findGame(string nickname);

        [OperationContract]
        Game getGame(string nickname);

        [OperationContract]
        bool cancelSearch(string nickname);

        [OperationContract]
        int DoAttack(string nickname, int myslot, int enslot);

        [OperationContract]
        void leaveGame(string nickname);

        [OperationContract]
        void Logout(string user);

        [OperationContract]
        List<Card> GetAllCard(string user, int page = 1);

        [OperationContract]
        bool ChangeCardslot(string user, int oslot, int nSlot);

        [OperationContract]
        int GetFreeSlotNumberAllCards(string user);

        [OperationContract]
        List<Card> BuyCard(string user, int number);

        [OperationContract]
        bool SellCard(string user, int slot);
        
    }
}
