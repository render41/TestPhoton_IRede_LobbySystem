using Photon.Pun;
using Photon.Realtime;
using Settings;
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

        [Header("Panels")]
        [SerializeField] private GameObject lobbyPanel;
        [SerializeField] private GameObject roomPanel;
        [SerializeField] private GameObject panels;

        private PanelManager _panelManager;

        #region Mono

        private void Awake()
        {
            _panelManager = panels.AddComponent<PanelManager>();
            PhotonNetwork.JoinLobby();
        }

        private void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            usernameTextTMP.text = $"Welcome, {PhotonNetwork.NickName}";
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)) OnClickCreateRoom();
        }

        #endregion

        public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

        public override void OnJoinedRoom()
        {
            _panelManager.SetActivePanels(roomPanel, lobbyPanel);
            roomNameTextTMP.text = $"Room: {PhotonNetwork.CurrentRoom.Name}";
        }
        public override void OnLeftRoom()
        {
            _panelManager.SetActivePanels(lobbyPanel, roomPanel);
        }

        public void JoinRoom(string roomName) => PhotonNetwork.JoinRoom(roomName);

        public void OnClickCreateRoom()
        {
            if (roomInputFieldTMP.text.Length < 1 && !PhotonNetwork.IsConnected) return;
            var roomOptions = new RoomOptions
            {
                MaxPlayers = 3
            };
            PhotonNetwork.JoinOrCreateRoom(roomInputFieldTMP.text, roomOptions, TypedLobby.Default);
            roomInputFieldTMP.text = "";
        }
        
        public void OnClickLeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}