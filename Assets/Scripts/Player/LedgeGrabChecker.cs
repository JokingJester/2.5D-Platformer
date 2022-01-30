using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrabChecker : MonoBehaviour
{
    [SerializeField] private Vector3 _handPos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ledge Grab Checker")
        {
            Player player = other.gameObject.transform.parent.GetComponent<Player>();
            if (player != null)
            {
                player.GrabLedge(_handPos);
            }
        }
    }
}
