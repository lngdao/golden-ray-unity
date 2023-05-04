using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenRay : MonoBehaviour
{
    LineRenderer rend;
    EdgeCollider2D col;

    void Start()
    {
        rend = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        Vector3[] linePoints = new Vector3[rend.positionCount];
        rend.GetPositions(linePoints);

        Vector2[] edgePoints = new Vector2[linePoints.Length];
        for (int i = 0; i < linePoints.Length; i++)
        {
            edgePoints[i] = transform.InverseTransformPoint(linePoints[i]);
        }

        col.points = edgePoints;
    }
}
