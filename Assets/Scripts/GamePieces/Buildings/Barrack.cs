using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Barrack : GamePiece
{
    public List<GameObject> unitsList;
    private Dictionary<string, GameObject> units = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        foreach (GameObject unit in unitsList)
        {
            units.Add(unit.name, unit);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Health.GetComponent<TextMeshProUGUI>().text = "HP " + _health;
    }

    public void CreateKnights()
    {
        GameObject knight = units.GetValueOrDefault("Knight");
        if (knight != default)
        {
            Instantiate(knight);
        }
    }

    //public void OpenBarrackMenu()
    //{
    //    MenuManager.instance.ResetMenu();
    //    menu.SetActive(true);
    //}

    //public void CloseBarrackMenu()
    //{
    //    MenuManager.instance.ResetMenu();
    //    menu.SetActive(false);
    //}
}


