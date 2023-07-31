//This is for handling all build menu buttons actions

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public List<GameObject> buildingsList;
    private Dictionary<string, GameObject> buildings = new Dictionary<string, GameObject>();
    private Button barrackButton;

    private void Start()
    {
        foreach (GameObject building in buildingsList)
        {
            buildings.Add(building.name, building);
        }
        barrackButton = MenuManager.instance.FindUIButton("Building", "Barrack Button");
        barrackButton.onClick.AddListener(CreateBarrack);
    }


    public void CreateBarrack()
    {
        GameObject barrack = buildings.GetValueOrDefault("Barrack BP");
        if (barrack != default) {
            Instantiate(barrack);
        }
    }
}
