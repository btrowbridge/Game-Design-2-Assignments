using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkLobbyPlayer : NetworkLobbyPlayer
{
    public GameObject playerPanelPrefab;

    [NonSerialized][SyncVar]
    public int materialIndex;

    [NonSerialized][SyncVar]
    public string playerName;

    private Text playerPanelName;
    private Image playerPanelReady;

    private GameObject panel;

    // Use this for initialization
    public void OnGUI()
    {
        if (panel != null && PanelManager.CurrentPanel == PanelManager.PanelType.WaitLobby)
        {
            playerPanelReady.enabled = readyToBegin;
        }
    }


    //panel not working
    public void SetPanel(GameObject p)
    {
        panel = p;
        playerPanelName = panel.GetComponentInChildren<Text>();
        playerPanelReady = panel.GetComponentsInChildren<Image>()[1];

        playerPanelName.text = (playerName != string.Empty) ? playerName : "DefaultName";

        playerPanelReady.enabled = readyToBegin;
    }

    private void OnDestroy()
    {
        if (panel != null)
            DestroyImmediate(panel);
    }

    
}