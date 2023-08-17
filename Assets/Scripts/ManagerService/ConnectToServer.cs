using Photon.Pun;
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

        public void OnClickConnect()
        {
            if (usernameInputField.text.Length < 1) return;
            PhotonNetwork.NickName = usernameInputField.text;
            buttonText.text = "Wait Connecting...";
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster() => SceneManager.LoadScene(sceneName);
    }
}
