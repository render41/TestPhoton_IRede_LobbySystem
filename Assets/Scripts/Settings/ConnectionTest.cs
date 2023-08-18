using Photon.Pun;
using Photon.Realtime;

namespace Settings
{
    public class ConnectionTest : MonoBehaviourPunCallbacks
    {
        public override void OnConnectedToMaster()
        {
            print("Connect to Server");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            print($"Disconnected from server for reason {cause}");
        }
    }
}
