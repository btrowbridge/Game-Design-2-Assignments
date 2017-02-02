using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Health : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    private Text healthText;

    private Slider healthBar;
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthText = GameObject.Find("txtCurrentHealth").GetComponent<Text>();
        healthBar = GameObject.Find("sliHealthBar").GetComponent<Slider>();
        healthBar.maxValue = MaxHealth;
    }
    void OnGUI()
    {
        healthBar.value = CurrentHealth;
        healthText.text = "Health: " + CurrentHealth;
    }
}

