using UnityEngine;
using UnityEngine.UI;

public class LipBody : MonoBehaviour
{
    private Vector3 ExPosition;
    private Quaternion ExRotation;
   public GameObject[] lipsColors ;
  
  

    public void UpdateTransform()
    {
        ExPosition = transform.position;
       ExRotation = transform.rotation;
      
    }

    public Vector3 GetExPosition()
    {
        return ExPosition;
    }

    public Quaternion GetExRotation()
    {
        return ExRotation;
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("GateLight"))
        {
            transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
           
            ParticleSystem ps = other.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            ps.Play();

            if (lipsColors[0].activeSelf)
            {
            
                lipsColors[0].SetActive(false);
                lipsColors[1].SetActive(true);
                transform.name = "pink";

            }
            else
              if (lipsColors[1].activeSelf)
            {
                // string name = lipsColors[i].name;
                lipsColors[1].SetActive(false);
                lipsColors[2].SetActive(true);
                transform.name = "blue";

            }

            else
               if (lipsColors[2].activeSelf)
            {
                // string name = lipsColors[i].name;
                lipsColors[2].SetActive(false);
                lipsColors[3].SetActive(true);
                transform.name = "yellow";

            }


        }
        if (other.transform.CompareTag("BackObstacle"))
        {
            transform.position = Vector3.back * 4f;
        }

        if (other.transform.CompareTag("FinishLevel"))
        {
            Transform lipManager = transform.parent;
            LipManager lipComponent = lipManager.GetComponent<LipManager>();

            lipComponent.ShowLeaderBoard();

        }
    }




        void OnTriggerExit(Collider other)
        {
        if (other.transform.CompareTag("GateLight"))
        {
            transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
        }

        }


  

}

