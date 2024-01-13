using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    
    [SerializeField] int resolution = 50; 
    [SerializeField] public float radius = 5f;   
    [SerializeField] public Material lineMaterial;
    
    void Start()
    {
        float rastgeleAci = Random.Range(0f, 360f);
        transform.Rotate(new Vector3(0, rastgeleAci, 0));
    }
    
    public void DrawCircleAroundObject()
    {
        LineRenderer lineRenderer;
        if (gameObject.GetComponent<LineRenderer>())
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
        }
        else
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        
        lineRenderer.material = lineMaterial;
        lineRenderer.widthMultiplier = 0.2f; 

        Vector3[] circlePoints = new Vector3[resolution + 1];
        for (int i = 0; i <= resolution; i++)
        {
            float angle = i * (2f * Mathf.PI / resolution);
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            circlePoints[i] = new Vector3(x, 0f, z) + transform.position;
        }

        lineRenderer.positionCount = resolution + 1;
        lineRenderer.SetPositions(circlePoints);

        lineRenderer.loop = true;
        Destroy(lineRenderer, 3f);
    }
}
