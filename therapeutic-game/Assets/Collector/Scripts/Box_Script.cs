using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Script : MonoBehaviour
{
    [SerializeField] private GameObject transparentBox;
    [SerializeField] private GameObject transparentTop;
    void Start()
    {
        Vector3 box = transparentBox.transform.localScale;
        transparentBox.transform.localScale = new Vector3(box.x, MainMenu.transparentBoxHeight, box.z);
        Transform topBox = transparentTop.transform;
        float halfSize = (MainMenu._screenSize - MainMenu.transparentBoxHeight) / 2;
        float topBoxPosition = (halfSize/2) + (MainMenu.transparentBoxHeight/2);
        transparentTop.transform.localScale = new Vector3(topBox.localScale.x, halfSize, topBox.localScale.z);
        transparentTop.transform.localPosition = new Vector3(topBox.localPosition.x, topBoxPosition, topBox.localPosition.z);
    }

    void Update()
    {
        
    }
}
