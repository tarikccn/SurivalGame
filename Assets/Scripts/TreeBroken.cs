using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TreeBroken : MonoBehaviour
{
    public bool isBroken = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isBroken = true;
        }
    }
}




