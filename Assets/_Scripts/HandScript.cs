using UnityEngine;
using System.Collections;

public class HandScript : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            Debug.Log("Hello");
            other.transform.parent = transform;
        }
    }

}