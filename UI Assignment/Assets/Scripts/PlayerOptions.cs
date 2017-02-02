using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOptions : MonoBehaviour {

    //Slider
    [Range(1,500)]
    public int MaxHealthLimit = 1;
    public Slider HealthSlider;
    public Text txtMaxHealth;

    public ToggleGroup TogGroup;

    public Dropdown drpCharacterSelect;

    public PlayerSpawn PlayerSpawnner;

    public Material PlayerMaterial;
    
    public List<GameObject> PlayerPrefabs;
    public List<ToggleColorPair> ToggleColorMap;


    [Serializable]
    public struct ToggleColorPair
    {
        public Toggle toggle;
        public Color color;
    }

	void Start () {
        HealthSlider.maxValue = MaxHealthLimit;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnGUI()
    {
        txtMaxHealth.text = "Max Health: " + HealthSlider.value;
    }

    public void CreatePlayer()
    {
        //Player Prefab
        int iCharacter = drpCharacterSelect.value;
        GameObject player = PlayerPrefabs[iCharacter];
        //Health
        var healthScript = player.GetComponent<Health>();
        healthScript.MaxHealth = Mathf.RoundToInt(HealthSlider.value);

        //Colors
        var activeToggle = TogGroup.ActiveToggles().FirstOrDefault();

        Color playerColor = (from TC in ToggleColorMap
                             where TC.toggle == activeToggle
                             select TC.color).FirstOrDefault();

        PlayerMaterial.color = playerColor;


        PlayerSpawnner.SpawnPalyer(player);
    }

    
}
