//This is for opening and closing specific menus and displaying specific buttons

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;
    public static MenuManager instance { get { return _instance; } }

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject buildMenu;

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
        ResetMenu();
        buildMenu.SetActive(true);
    }

    //Display Main Menu
    public void OpenMainMenu()
    {
        ResetMenu();
        mainMenu.SetActive(true);
    }

    public void ResetMenu()
    {
        mainMenu.SetActive(false);
        buildMenu.SetActive(false);
    }

    public Button FindUIButton(string menuType, string button)
    {
        if (menuType == "Building")
        {
            return buildMenu.transform.Find(button).GetComponent<Button>();
        }
        return null;
    }
}