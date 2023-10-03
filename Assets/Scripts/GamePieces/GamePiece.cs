using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GamePiece : MonoBehaviour
{
    [SerializeField] protected GameObject UI;
    [SerializeField] protected GameObject Health;
    protected int _health;

    public void OpenMenu()
    {
        MenuManager.instance.ResetMenu();
        if (UI != null)
        {
            UI.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        MenuManager.instance.ResetMenu();
        if (UI != null)
        {
            UI.SetActive(false);
        }
    }
}
