using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyLobbyManager : NetworkLobbyManager
{
    public Text clientNameInput;
    public Text hostInput;
    public Text portInput;
    public GameObject playerPanelPrefab;
    // Use this for initialization
    private void Start()
    {
        dontDestroyOnLoad = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnButtonHost()
    {
        if (!SetIPAddress()) return;
        singleton.StartHost();
        PanelManager.SwitchToPanel(PanelManager.PanelType.WaitLobby);       
    }

    public void OnButtonConnect()
    {
        if (!SetIPAddress()) return;
        singleton.StartClient();
        PanelManager.SwitchToPanel(PanelManager.PanelType.WaitLobby);

    }
    public void OnButtonStop()
    {
        StopHost();
    }
    public void OnButtonReady()
    {
        foreach(var lobbyPlayer in lobbySlots)
        {
            if (lobbyPlayer != null && lobbyPlayer.isLocalPlayer)
                lobbyPlayer.readyToBegin = true;
        }
    }

    public void SetLocalPlayerMaterial(Material mat)
    {
        foreach (var lobbyPlayer in lobbySlots)
        {
        }
    }
    private bool SetIPAddress()
    {
        int portInt;
        string portString = (portInput.text != string.Empty) ? portInput.text : "7777";
        string hostString = (hostInput.text != string.Empty) ? hostInput.text : "localhost";
        if (int.TryParse(portString, out portInt))
        {
            singleton.networkAddress = hostString;
            singleton.networkPort = portInt;
            return true;
        }
        else
        {
            Debug.Log("Bad port input");
            return false;
        }
    }

    
    public override void OnLobbyClientEnter()
    {
        base.OnLobbyClientEnter();
        foreach (var lobbyPlayer in lobbySlots)
        {
            if (lobbyPlayer != null && lobbyPlayer.isLocalPlayer)
                lobbyPlayer.GetComponent<MyNetworkLobbyPlayer>().name = clientNameInput.text;
        }
    }

    public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
    {
        var lp = lobbyPlayer.GetComponent<MyNetworkLobbyPlayer>();
        var gp = gamePlayer.GetComponent<GamePlayer>();
        gp.materialIndex = lp.materialIndex;
        gp.name = lp.name;
        return true;
    }

    public override void OnClientError(NetworkConnection conn, int errorCode)
    {
        base.OnClientError(conn, errorCode);
        PanelManager.SwitchToPanel(PanelManager.PanelType.ConnectionMenu);
        Debug.Log(errorCode);
    }

    public override void OnServerError(NetworkConnection conn, int errorCode)
    {
        base.OnServerError(conn, errorCode);
        PanelManager.SwitchToPanel(PanelManager.PanelType.ConnectionMenu);
        Debug.Log(errorCode);
    }

    public override void OnLobbyStartHost()
    {
        base.OnLobbyStartHost();
        PanelManager.SwitchToPanel(PanelManager.PanelType.WaitLobby);

    }
    public override void OnLobbyStartClient(NetworkClient lobbyClient)
    {
        base.OnLobbyStartClient(lobbyClient);
        PanelManager.SwitchToPanel(PanelManager.PanelType.WaitLobby);
    }
    public override void OnLobbyStopHost()
    {
        base.OnLobbyStopHost();
        PanelManager.SwitchToPanel(PanelManager.PanelType.ConnectionMenu);
    }
    public override void OnLobbyStopClient()
    {
        base.OnLobbyStopClient();
        PanelManager.SwitchToPanel(PanelManager.PanelType.ConnectionMenu);
    }

    public override void OnLobbyServerPlayersReady()
    {
        base.OnLobbyServerPlayersReady();
        PanelManager.SwitchToPanel(PanelManager.PanelType.None);

    }

}