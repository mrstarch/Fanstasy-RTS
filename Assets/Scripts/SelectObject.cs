//Gets the screen point and determines if we need to select or deselect units and buildings

using UnityEngine;
using UnityEngine.EventSystems;

public class SelectObject : MonoBehaviour
{
    private SelectedObjectDictionary selectedTable;
    private RaycastHit hit;
    private bool dragSelect = false;

    private Vector3 p1; //First point mouse is clicked at
    private Vector3 p2; //Second point if mouse has been dragged

    private MeshCollider selectionBox;
    private Mesh selectionMesh;

    private Vector2[] corners; //Corners of selection box
    private Vector3[] groundRectangleCorners; // vertices of rectangle on the ground
    private Vector3[] topRectangleCorners; // vertices of rectangle in the air

    // Start is called before the first frame update
    void Start()
    {
        selectedTable = GetComponent<SelectedObjectDictionary>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press ESC key
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            selectedTable.RemoveAllSelected();
        }

        //Mouse has been pressed down
        if (Input.GetMouseButtonDown(0))
        {
            p1 = Input.mousePosition;
        }

        //Mouse has been dragged and held down
        if (Input.GetMouseButton(0))
        {
            if ((p1 - Input.mousePosition).magnitude > 40)
            {
                dragSelect = true;
            }
        }

        //Mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            //If UI element is clicked do nothing
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //Single click or click with shift
            if(!dragSelect)
            {
                Ray ray = Camera.main.ScreenPointToRay(p1);

                if (Physics.Raycast(ray, out hit, 50000.0f, LayerMask.GetMask("BuildingsAndUnits")))
                {
                    if(Input.GetKey(KeyCode.LeftShift))
                    {
                        selectedTable.AddSelected(hit.transform.gameObject);
                    }
                    else
                    {
                        selectedTable.RemoveAllSelected();
                        selectedTable.AddSelected(hit.transform.gameObject);
                    } 
                }
                else
                {
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        selectedTable.RemoveAllSelected();
                    }
                }
            }
            //Logic for selecting with drag select
            else
            {
                groundRectangleCorners = new Vector3[4];
                topRectangleCorners = new Vector3[4];

                p2 = Input.mousePosition;
                corners = GetBoundingBox(p1,p2); //Get the corners of the on screen drawn selection box

                //For each corner send out a Ray until it hits the ground
                int i = 0;
                foreach(Vector2 corner in corners)
                {
                    Ray ray = Camera.main.ScreenPointToRay(corner);
                    if(Physics.Raycast(ray, out hit, 50000.0f, LayerMask.GetMask("Ground")))
                    {
                        groundRectangleCorners[i] = new Vector3(hit.point.x, 0, hit.point.z); //Grab the corner on the ground
                        topRectangleCorners[i] = ray.origin - hit.point; // calculate a mirror of the rectangle on the camera level (used later for calculations of mesh)
                    }
                    i++;
                }

                //Generate the mesh
                selectionMesh = generateSelectionMesh(groundRectangleCorners, topRectangleCorners);
                selectionBox = gameObject.AddComponent<MeshCollider>();
                selectionBox.sharedMesh = selectionMesh;
                selectionBox.convex = true;
                selectionBox.isTrigger = true;

                //If shift is not hold down we will remove all other selections
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    selectedTable.RemoveAllSelected();
                }

                Destroy(selectionBox, 0.02f);

            }//end marquee select

            dragSelect = false;

        }
    }
    
    //Draw the drag box on screen
    private void OnGUI()
    {
        if(dragSelect)
        {
            var rect = Utils.GetScreenRect(p1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new UnityEngine.Color(255.0f, 255.0f, 255.0f, 0.1f));
            Utils.DrawScreenRectBorder(rect, 2, new UnityEngine.Color(255.0f, 255.0f, 255.0f));
        }
    }

    //Get corners of our drawn selection Box
    private Vector2[] GetBoundingBox(Vector3 p1, Vector3 p2) 
    {
        Vector3 botLeft = Vector3.Min(p1, p2);
        Vector3 topRight = Vector3.Max(p1, p2);

        // Order of indexes for corners
        // 0 = top left; 1 = top right; 2 = bottom left; 3 = bottom right;
        return new Vector2[]
                {
                    new Vector2(botLeft.x, topRight.y),
                    new Vector2(topRight.x, topRight.y),
                    new Vector2(botLeft.x, botLeft.y),
                    new Vector2(topRight.x, botLeft.y)
                };
    }

    //Generate a mesh from the 2 rectangles
    private Mesh generateSelectionMesh(Vector3[] groundRectangleCorners, Vector3[] topRectangleCorners)
    {
        Vector3[] vertices = new Vector3[8];

        //Assign the groundRectangleCorners to vertices
        for (int i = 0; i < 4; i++)
        {
            vertices[i] = groundRectangleCorners[i];
        }

        //Calculate top vertices from the groundRectangleCorners and topRectangleCorners
        for (int j = 4; j < 8; j++)
        {
            vertices[j] = groundRectangleCorners[j - 4] + topRectangleCorners[j - 4];
        }

        Mesh selectionMesh = new Mesh();
        selectionMesh.vertices = vertices;
        selectionMesh.triangles = new int[]{0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 }; //map the tris of our cube

        return selectionMesh;
    }

    //When the Mesh collides with any object it will be selected
    private void OnTriggerEnter(Collider other)
    {
        selectedTable.AddSelected(other.gameObject);
    }
}

