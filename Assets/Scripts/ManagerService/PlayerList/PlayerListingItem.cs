using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace ManagerService.PlayerList
{
    public class PlayerListingItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerNameTextTMP;
        public Player Player { get; private set; }
        public void SetPlayerInfo(Player player)
        {
            Player = player;
            playerNameTextTMP.text = player.NickName;
        }
    }
}
