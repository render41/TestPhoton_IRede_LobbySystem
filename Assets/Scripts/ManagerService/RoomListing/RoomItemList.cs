using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace ManagerService.RoomListing
{
    public class RoomItemList : MonoBehaviour
    {
        [SerializeField] private TMP_Text roomName;
        private LobbyManager _lobbyManager;
        
        public RoomInfo RoomInfo { get; private set; }
        
        private void Start() => _lobbyManager = FindObjectOfType<LobbyManager>();

        public void SetRoomName(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            roomName.text = roomInfo.Name;
        }
        
        public void OnClickItem() => _lobbyManager.JoinRoom(roomName.text);
    }
}
