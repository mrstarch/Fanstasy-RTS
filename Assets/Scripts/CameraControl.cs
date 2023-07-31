//Controlling the camera is done here

using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(0,20,-20);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        gameObject.transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime, Space.World);
        gameObject.transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime, Space.World);
        gameObject.transform.Translate(Vector3.up * scrollInput * speed * Time.deltaTime, Space.World);
    }
}
