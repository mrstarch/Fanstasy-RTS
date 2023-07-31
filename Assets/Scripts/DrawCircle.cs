using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{

    public LineRenderer circleRenderer;

    // Start is called before the first frame update
    void Start()
    {
        DrawCircleForObject(100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawCircleForObject(int steps, float radius)
    {
        circleRenderer.positionCount = steps;

        for(int currStep = 0; currStep < steps; currStep++)
        {
            float circumferenceProgress = (float)currStep / (steps);
            float currRadian = circumferenceProgress * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currRadian);
            float zScaled = Mathf.Sin(currRadian);

            float x = xScaled* radius;
            float z = zScaled* radius;
            
            Vector3 currPos = new Vector3(x, 0, z);
            circleRenderer.SetPosition(currStep, currPos);
        }
    }
}
