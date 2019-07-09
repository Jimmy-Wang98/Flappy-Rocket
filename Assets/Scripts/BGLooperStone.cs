using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooperStone : MonoBehaviour
{

    int numBGPanels = 30;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered: " + collider.name);

        float widthOfBGObject = ((BoxCollider2D)collider).size.x;

        Vector3 pos = collider.transform.position;

        pos.x += widthOfBGObject * numBGPanels - widthOfBGObject / 2f;

        collider.transform.position = pos;
    }
}