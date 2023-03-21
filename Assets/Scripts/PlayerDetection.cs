using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool found = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            found = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            found = false;
        }
    }
}
