using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelManager : MonoBehaviour {

    [System.Serializable]
    public class GUIPanel
    {
        public PanelType type;
        public GameObject panel;
    }

    public enum PanelType
    {
        None,
        ConnectionMenu,
        WaitLobby,
        HUD
    }

    private static PanelType currentPanel;
    public static PanelType CurrentPanel
    {
        get
        {
            return currentPanel;
        }
    }

    private static PanelManager instance = null;
    
    [SerializeField]
    public List<GUIPanel> panelList;

    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        currentPanel = PanelType.ConnectionMenu;
    }

    public static void SwitchToPanel(PanelType panelType)
    {
        foreach (var p in instance.panelList)
        {
            p.panel.SetActive(p.type == panelType);
        }
        currentPanel = panelType;
    }

}
