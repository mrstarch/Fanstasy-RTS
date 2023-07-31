//This is for opening and closing specific menus and displaying specific buttons

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;
    public static MenuManager instance { get { return _instance; } }

    [SerializeField] Button backButton;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject buildMenu;
    [SerializeField] GameObject barrackMenu;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Display Build Menu and Back Button
    public void OpenBuildMenu()
    {
        SetAllFalse();
        backButton.gameObject.SetActive(true);
        buildMenu.SetActive(true);
    }

    //Display Main Menu
    public void OpenMainMenu()
    {
        SetAllFalse();
        mainMenu.SetActive(true);
    }

    public void OpenBarrackMenu()
    {
        SetAllFalse();
        Button barrack  = FindUIButton("Barrack", "Knight Button");
        barrackMenu.SetActive(true);
    }

    private void SetAllFalse()
    {
        backButton.gameObject.SetActive(false); ;
        mainMenu.SetActive(false); ;
        buildMenu.SetActive(false); ;
        barrackMenu.SetActive(false); ;
    }

    public Button FindUIButton(string menuType, string button)
    {
        if (menuType == "Building")
        {
            return buildMenu.transform.Find(button).GetComponent<Button>();
        }
        if (menuType == "Barrack")
        {
            return barrackMenu.transform.Find(button).GetComponent<Button>();
        }
        return null;
    }
}