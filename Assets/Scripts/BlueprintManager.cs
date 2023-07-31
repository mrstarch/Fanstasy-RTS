//Handles moving and checking blueprints

using UnityEngine;

public class BlueprintManager : MonoBehaviour
{
    RaycastHit hit;
    public GameObject prefab;
    private int collisionCount;
    private Material grayBPMaterial;
    private Material redBPMaterial;

    // Start is called before the first frame update
    void Start()
    {
        grayBPMaterial = Resources.Load("Materials/Gray BP", typeof(Material)) as Material;
        redBPMaterial = Resources.Load("Materials/Red BP", typeof(Material)) as Material;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8)))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
            transform.position = hit.point;
        }

        if (Input.GetMouseButton(0) && IsNotColliding())
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collisionCount++;
        gameObject.GetComponentInChildren<Renderer>().material = redBPMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        collisionCount--;
        if (IsNotColliding())
        {
            gameObject.GetComponentInChildren<Renderer>().material = grayBPMaterial;
        }
    }

    private bool IsNotColliding() {
        return collisionCount == 0;
    }
}
