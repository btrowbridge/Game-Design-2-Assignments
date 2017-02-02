using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIClickEvents : MonoBehaviour {

    [Serializable]
    public enum PanelName
    {
        Main,
        Credits,
        Options,
        Game
    }

    [Serializable]
    public struct PanelOptions
    {
        public PanelName PanelName;
        public GameObject Panel;
    }

    public List<PanelOptions> PanelMap;

    void Start()
    {
        ChangePanelTo(PanelName.Main);
    }

    public void ChangePanelTo(int iPanel)
    {
        PanelName panelName = PanelMap[iPanel].PanelName;

        foreach (var panelOption in PanelMap)
        {
            panelOption.Panel.SetActive(panelOption.PanelName == panelName);
        }
    }
    public void ChangePanelTo(PanelName panelName)
    {
        int iPanel = PanelMap.FindIndex(i => i.PanelName == panelName);
        ChangePanelTo(iPanel);
    }
}
