using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrack : MonoBehaviour
{
    //private SelectedObjectDictionary selectedTable;
    //private MenuManager menuManager;

    public List<GameObject> unitsList;
    private Dictionary<string, GameObject> units = new Dictionary<string, GameObject>();
    [SerializeField] GameObject barrackMenu;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject unit in unitsList)
        {
            units.Add(unit.name, unit);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CreateKnights()
    {
        GameObject knight = units.GetValueOrDefault("Knight");
        if (knight != default)
        {
            Instantiate(knight);
        }
    }

    public void OpenBarrackMenu()
    {
        MenuManager.instance.ResetMenu();
        barrackMenu.SetActive(true);
    }

    public void CloseBarrackMenu()
    {
        MenuManager.instance.ResetMenu();
        barrackMenu.SetActive(false);
    }
}


