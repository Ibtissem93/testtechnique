using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLips : MonoBehaviour
{
    public Transform SnakeParent;

 
    void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.tag == "LipsBody")
            {
            Transform lipManager = other.transform.parent;
            LipManager lipComponent = lipManager.GetComponent<LipManager>();
            lipComponent.ThrowLips(other.gameObject);
            float x = Random.Range(-0.7f, 1.2f);
            float z = Random.Range(0.7f, 1.2f);
            other.transform.position += new Vector3(x,0, z);
           // other.gameObject.GetComponent<Rigidbody>().velocity=(Vector3.up * 1f);
            other.transform.position += Vector3.forward * 2f;

            other.gameObject.AddComponent<LipAfterDestroy>();

        }

       
    }

   
}
