using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GamePlayer : NetworkBehaviour
{
    [SyncVar]
    public string playerName;
    [SyncVar]
    public int materialIndex;

    private MaterialManager materialManager;
    // Use this for initialization
    private void Start()
    {
        var nameText = GetComponentInChildren<Text>();
        if (isLocalPlayer)
        {
            nameText.enabled = false;
        }
        nameText.text = (playerName != string.Empty) ? playerName : "DefaultName";
        materialManager = FindObjectOfType<MaterialManager>();
    }
    private void Awake()
    {
        if (materialManager != null)
            SetMaterial();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void SetMaterial()
    {
        var material = materialManager.AvailableMaterials[materialIndex];
        var renderers = GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
        {
            r.material = material;
        }
    }

}