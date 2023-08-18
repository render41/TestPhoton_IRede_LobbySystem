using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ManagerService
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField usernameInputField;
        [SerializeField] private TMP_Text buttonText;
        [SerializeField] private string sceneName = "Lobby";
        private bool _isConnecting;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return) && !_isConnecting) OnClickConnect();
        }
        
        public void OnClickConnect()
        {
            if (usernameInputField.text.Length < 1) return;
            _isConnecting = true;
            PhotonNetwork.NickName = usernameInputField.text;
            buttonText.text = "Wait Connecting...";
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster() => SceneManager.LoadScene(sceneName);
        
        public override void OnDisconnected(DisconnectCause cause)
        {
            _isConnecting = false;
            buttonText.text = "Connect";
            Debug.LogWarning($"Disconnected from server: {cause}");
        }
    }
}
