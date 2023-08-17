using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace ManagerService
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [Header("Manager Lobby")]
        [SerializeField] private TMP_Text usernameTextTMP;
        [SerializeField] private TMP_InputField roomInputFieldTMP;
        [SerializeField] private TMP_Text roomNameTextTMP;
        
        [Header("Room Settings")]
        [SerializeField] private RoomItem roomItemPrefab;
        [SerializeField] private Transform contentObjects;
        [SerializeField] private float timeBetweenUpdates = 1.5f;
        private readonly List<RoomItem> _roomItemsList = new List<RoomItem>();
        private float _nextUpdateTime;

        [Header("Panels")]
        [SerializeField] private GameObject lobbyPanel;
        [SerializeField] private GameObject roomPanel;

        #region Mono
        private void Start()
        {
            PhotonNetwork.JoinLobby();
            usernameTextTMP.text = $"Welcome, {PhotonNetwork.NickName}";
        }

        #endregion

        public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();
        
        public void OnClickCreateRoom()
        {
            if (roomInputFieldTMP.text.Length < 1) return;
            PhotonNetwork.CreateRoom(roomInputFieldTMP.text, new RoomOptions() { MaxPlayers = 4 });
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public override void OnJoinedRoom()
        {
            lobbyPanel.SetActive(false);
            roomPanel.SetActive(true);
            roomNameTextTMP.text = $"Room: {PhotonNetwork.CurrentRoom.Name}";
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (!(Time.time >= _nextUpdateTime)) return;
            UpdateRoomList(roomList);
            _nextUpdateTime = Time.time + timeBetweenUpdates;
        }

        private void UpdateRoomList(List<RoomInfo> roomInfoList)
        {
            foreach (var item in _roomItemsList) Destroy(item.gameObject);
            _roomItemsList.Clear();
            
            foreach (var room in roomInfoList)
            {
                var newRoom = Instantiate(roomItemPrefab, contentObjects);
                newRoom.SetRoomName(room.Name);
                _roomItemsList.Add(newRoom);
            }
        }

        public void JoinRoom(string roomName) => PhotonNetwork.JoinRoom(roomName);

        public void OnClickLeaveRoom() => PhotonNetwork.LeaveRoom();

        public override void OnLeftRoom()
        {
            roomPanel.SetActive(false);
            lobbyPanel.SetActive(true);
        }
    }
}