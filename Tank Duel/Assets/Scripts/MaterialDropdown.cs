using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MaterialDropdown : NetworkBehaviour {

    public GameObject DummyPrefab;
    private Dropdown dropdown;

    private List<Material> materialList;
	// Use this for initialization
    void Start()
    {
        materialList = FindObjectOfType<MaterialManager>().AvailableMaterials;
        dropdown = GetComponent<Dropdown>();
        PopulateDropdown();
    }
    private void PopulateDropdown()
    {
        if (dropdown.options.Count > 0)
            dropdown.ClearOptions();
        foreach(var mat in materialList)
        {
            var data = new Dropdown.OptionData(mat.name);
            dropdown.options.Add(data);
        }
    }
    public void MaterialPreview()
    {
        int iMaterial = dropdown.value;
        DummyMaterialChange(materialList[iMaterial]);
    }
    void DummyMaterialChange(Material mat)
    {
        var renderMeshes = DummyPrefab.GetComponentsInChildren<MeshRenderer>();
        foreach(var mesh in renderMeshes)
        {
            mesh.material = mat;
        }
    }
    
    public void SetLocalLobbyPlayerMaterial()
    {
        var lobbyPlayers = FindObjectsOfType<MyNetworkLobbyPlayer>();
        foreach(var lp in lobbyPlayers)
        {
            if (lp.isLocalPlayer)
            {
                lp.materialIndex = dropdown.value;
            }
        }
    }
}
