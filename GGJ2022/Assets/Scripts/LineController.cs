using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    // Creates a line renderer that follows a Sin() function
    // and animates it.

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 20;
    public GameObject point1;
    public GameObject point2;
    void Start()
    {
        //LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        //lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        //lineRenderer.widthMultiplier = 0.2f;
        //lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        //float alpha = 1.0f;
        //Gradient gradient = new Gradient();




    }

    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        
        lineRenderer.SetPosition(0, point1.transform.position);
        if (point2 != null)
        {
            lineRenderer.SetPosition(1, point2.transform.position);
        }



    }
}