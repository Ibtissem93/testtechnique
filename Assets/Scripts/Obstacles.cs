using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "LipsBody")
        {
           
            Transform lipManager = other.transform.parent;
            LipManager lipComponent = lipManager.GetComponent<LipManager>();
           lipComponent.DeleteLip(other.gameObject);
            Destroy(other.gameObject);

        }


    }
}
