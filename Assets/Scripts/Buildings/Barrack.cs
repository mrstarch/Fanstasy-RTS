using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrack : MonoBehaviour
{
    //private SelectedObjectDictionary selectedTable;
    //private MenuManager menuManager;

    public List<GameObject> unitsList;
    private Dictionary<string, GameObject> units = new Dictionary<string, GameObject>();
    private Button knightButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject unit in unitsList)
        {
            units.Add(unit.name, unit);
        }
        
        knightButton = MenuManager.instance.FindUIButton("Barrack", "Knight Button");
        Instantiate(knightButton);
        knightButton.onClick.AddListener(CreateKnights);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.selectedObjectDictionary.GetSelectedCount() == 1 && GameManager.instance.selectedObjectDictionary.IsInTable(gameObject.GetInstanceID()))
        {
            MenuManager.instance.OpenBarrackMenu();
        }
    }

    public void CreateKnights()
    {
        GameObject knight = units.GetValueOrDefault("Knight");
        if (knight != default)
        {
            Instantiate(knight);
        }
    }
}


