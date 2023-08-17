using System;
using TMPro;
using UnityEngine;

namespace ManagerService
{
    public class RoomItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text roomName;
        private LobbyManager _lobbyManager;

        private void Start() => _lobbyManager = FindObjectOfType<LobbyManager>();

        public void SetRoomName(string _roomName) => roomName.text = _roomName;

        public void OnClickItem() => _lobbyManager.JoinRoom(roomName.text);
    }
}
