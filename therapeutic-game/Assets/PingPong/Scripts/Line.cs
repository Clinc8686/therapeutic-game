using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private Vector3 screenSize;
    private LineRenderer lr;
    private float topBorder;
    private float bottomBorder;
    
    void Start()
    {
        
        createDottedLine();
    }
    
    void Update()
    {
        
    }

    private void createDottedLine()
    {
        lr = GetComponent<LineRenderer>();
        screenSize = Camera.main.WorldToViewportPoint(transform.position);
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenSize.z)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).y;

        float countedLinePosition = (bottomBorder * -1) + topBorder + 1;
        float LineCounter = bottomBorder;
        Vector3[] LinePositions = new Vector3[(int) countedLinePosition];
        for (int i = 0; i < countedLinePosition; i++)
        {
            LinePositions[i] = new Vector3(0.0f,LineCounter,0.0f);
            LineCounter += 1;
        }

        lr.positionCount = (int) countedLinePosition;
        lr.SetPositions(LinePositions);
    }
}
