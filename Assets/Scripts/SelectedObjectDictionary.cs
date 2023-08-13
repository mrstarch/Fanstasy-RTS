//Contains and handles all selection action for buildings and units 

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectedObjectDictionary : MonoBehaviour
{
    //public static SelectedObjectDictionarySingleton instance { get; private set; }

    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();

    public void AddSelected(GameObject gObject)
    {
        int id = gObject.GetInstanceID();

        if(!selectedTable.ContainsKey(id))
        {
            selectedTable.Add(id, gObject);
            gObject.transform.Find("Selection Indicator").gameObject.SetActive(true);
            gObject.GetComponent<Barrack>().OpenBarrackMenu();
        }
    }

    public void RemoveSelected(GameObject gObject)
    {
        int id = gObject.GetInstanceID();

        if (selectedTable.ContainsKey(id))
        {
            selectedTable.Remove(id);
            gObject.transform.Find("Selection Indicator").gameObject.SetActive(false);
        }
    }

    public void RemoveAllSelected() 
    { 
        foreach(GameObject gObject in selectedTable.Values)
        {
            gObject.transform.Find("Selection Indicator").gameObject.SetActive(false);
            gObject.GetComponent<Barrack>().CloseBarrackMenu();
        }
        selectedTable.Clear();
        MenuManager.instance.OpenMainMenu();
    }

    public int GetSelectedCount()
    {
        return selectedTable.Count;
    }

    public bool IsInTable(int id)
    {
        return selectedTable.ContainsKey(id);
    }
}
