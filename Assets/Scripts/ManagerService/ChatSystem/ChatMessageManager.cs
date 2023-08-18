using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace ManagerService.ChatSystem
{
    public class ChatMessageManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField messageInputField;
        [SerializeField] private TextMeshProUGUI chatContent;
        [Range(3, 14)][SerializeField] private int maximumMessages = 12;
        
        private PhotonView _photonView;
        private readonly List<string> _messages = new List<string>();
        private float _buildDelay = 0.0f;

        private void Start() => _photonView = GetComponent<PhotonView>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)) SubmitMessageChat();
            UpdateChat();
        }

        [PunRPC]
        private void AddMessageRPC(string message) => _messages.Add(message);

        private void SendMessageChat(string message)
        {
            var newMessage = $"{PhotonNetwork.NickName}: {message}";
            _photonView.RPC("AddMessageRPC", RpcTarget.All, newMessage);
        }

        public void SubmitMessageChat()
        {
            var blankCheck = messageInputField.text;
            blankCheck = Regex.Replace(blankCheck, @"\s", "");
            if (blankCheck == "")
            {
                messageInputField.ActivateInputField();
                messageInputField.text = "";
                return;
            }
            
            SendMessageChat(messageInputField.text);
            messageInputField.ActivateInputField();
            messageInputField.text = "";
        }

        private void BuildChatContents()
        {
            var newContents = _messages.Aggregate("", (current, s) => current + (s + "\n"));
            chatContent.text = newContents;
        }

        private void UpdateChat()
        {
            switch (PhotonNetwork.InRoom)
            {
                case true:
                {
                    chatContent.maxVisibleLines = maximumMessages;
                    if (_messages.Count > maximumMessages)
                    {
                        _messages.RemoveAt(0);
                    }

                    if (!(_buildDelay < Time.time)) return;
                    BuildChatContents();
                    _buildDelay = Time.time + 0.25f;
                    break;
                }
                default:
                {
                    if (_messages.Count > 0)
                    {
                        _messages.Clear();
                        chatContent.text = "";
                    }

                    break;
                }
            }
        }
    }
}
