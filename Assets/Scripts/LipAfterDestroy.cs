using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LipAfterDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollisionCone")
        {
            Transform lipManager = other.transform.parent.parent;
            LipManager lipComponent = lipManager.GetComponent<LipManager>();

            lipComponent.AddBodyy(transform.name);


            Destroy(gameObject);
        }
    }
}
