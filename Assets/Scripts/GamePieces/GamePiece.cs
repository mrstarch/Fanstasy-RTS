using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePiece : MonoBehaviour
{
    [SerializeField] protected GameObject menu;
    protected int health;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void OpenMenu()
    {
        MenuManager.instance.ResetMenu();
        if (menu != null)
        {
            menu.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        MenuManager.instance.ResetMenu();
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }
}
