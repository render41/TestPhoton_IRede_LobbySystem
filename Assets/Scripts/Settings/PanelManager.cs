using UnityEngine;

namespace Settings
{
    public class PanelManager : MonoBehaviour
    {
        public void SetActivePanels(GameObject activePanel, GameObject inactivePanel)
        {
            activePanel.SetActive(true);
            inactivePanel.SetActive(false);
        }
    }
}
