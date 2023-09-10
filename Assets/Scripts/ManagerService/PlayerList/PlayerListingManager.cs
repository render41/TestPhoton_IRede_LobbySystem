using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace ManagerService.PlayerList
{
    public class PlayerListingManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private PlayerListingItem playerListingItemPrefab;
        [SerializeField] private Transform contentPlayerList;

        private readonly List<PlayerListingItem> _listingItem = new List<PlayerListingItem>();

        private void Awake() => GetCurrentRoomPlayer();

        private void GetCurrentRoomPlayer()
        {
            foreach (var playerInfo in PhotonNetwork.CurrentRoom.Players)
            {
                AddPLayerList(playerInfo.Value);
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            AddPLayerList(newPlayer);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            RemovePlayer(otherPlayer);
        }

        private void AddPLayerList(Player player)
        {
            var listingItem = Instantiate(playerListingItemPrefab, contentPlayerList);
            if (listingItem == null) return;
            listingItem.SetPlayerInfo(player);
            _listingItem.Add(listingItem);
        }

        private void RemovePlayer(Player otherPlayer)
        {
            var index = _listingItem.FindIndex(x => Equals(x.Player, otherPlayer));
            if (index == 1) return;
            Destroy(_listingItem[index].gameObject);
            _listingItem.RemoveAt(index);
        }
    }
}
