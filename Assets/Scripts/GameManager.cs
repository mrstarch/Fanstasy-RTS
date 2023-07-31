//Any game mechanics will be done here

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }
    public SelectedObjectDictionary selectedObjectDictionary { get; private set; }
    public SelectObject selectObject { get; private set; }
    public BuildManager buildManager { get; private set; }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        selectedObjectDictionary = GetComponentInChildren<SelectedObjectDictionary>();
        selectObject = GetComponentInChildren<SelectObject>();
        buildManager = GetComponentInChildren<BuildManager>();
    }
}
