using UnityEngine;

public class LipFood : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollisionCone")
        {
            Transform lipManager = other.transform.parent.parent;
            LipManager lipComponent = lipManager.GetComponent<LipManager>();

            lipComponent.AddBody();
         

            Destroy(gameObject);
        }
    }
}

