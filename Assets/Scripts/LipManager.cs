using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LipManager : MonoBehaviour
{
    public float speed;
    private float currentSpeed;

    public GameObject partPrefab;
    public GameObject conePrefab;

    private float distance;
    private List<Transform> parts;

    private float nailTransformTimer;
    private Camera camera;
    private float Distance;
    public GameObject RedLip;
    public GameObject PinkLip;
    public GameObject BlueLip;
    public GameObject YellowLip;
    public GameObject LeaderBoard;
    public Text ScoreText;
    bool move = true;


    void Start()
    {
        currentSpeed = speed;
        distance = partPrefab.transform.localScale.z;
        parts = new List<Transform>();
        nailTransformTimer = distance;
        camera = Camera.main;

    

        Transform head = Instantiate(partPrefab, transform).transform;
        head.gameObject.tag = "LipHead";
        // Instantiate(conePrefab,head);
        GameObject firstLip = Instantiate(conePrefab, head.transform.position - (head.transform.forward), head.transform.rotation);
        firstLip.transform.SetParent(head.transform);
        parts.Add(head);
        Distance = Vector3.Distance(camera.transform.position, head.position);


    }

    void FixedUpdate()
    {
     
        UpdateNailTransforms();
        if(move)
        { Move(); }
       
  
    }

    public void AddBody()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, parts.Count * +distance);
        Transform part = Instantiate(partPrefab, spawnPosition , Quaternion.identity, transform).transform;
        part.gameObject.tag = "LipsBody";
    


        parts.Add(part);
 
    }

    public void AddBodyy(string name)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, parts.Count * +distance);
        switch (name)
        {
            case "red":
                Transform part = Instantiate(RedLip, spawnPosition, Quaternion.identity, transform).transform;
                part.gameObject.tag = "LipsBody";
                parts.Add(part);
                break;

            case "pink":
                Transform partp = Instantiate(PinkLip, spawnPosition, Quaternion.identity, transform).transform;
                partp.gameObject.tag = "LipsBody";
                parts.Add(partp);
                break;

            case "blue":
                Transform partb = Instantiate(BlueLip, spawnPosition, Quaternion.identity, transform).transform;
                partb.gameObject.tag = "LipsBody";
                parts.Add(partb);
                break;

            case "yellow":
                Transform party = Instantiate(YellowLip, spawnPosition, Quaternion.identity, transform).transform;
                party.gameObject.tag = "LipsBody";
                parts.Add(party);

                break;
        }
       
    }



    void UpdateNailTransforms()
    {
        nailTransformTimer += Time.deltaTime;

        if (nailTransformTimer >= distance / (currentSpeed + float.Epsilon))
        {
            for (int i = 0; i < parts.Count; i++)
            {
                parts[i].GetComponent<LipBody>().UpdateTransform();
            }

            nailTransformTimer = 0.0f;
        }
    }

    void Move()
    {
        // Move snake head

        Vector3 lookAtVector = parts[0].position + Vector3.forward;

      
            // Mobile movement

            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);

            //    Vector3 screenPosition = new Vector3(touch.position.x, touch.position.y, cameraToHeadDistance);
            //    Vector3 worldPosition = currentCamera.ScreenToWorldPoint(screenPosition);

            //    lookAtVector.x = Mathf.Clamp(worldPosition.x, -1.45f, 1.45f);
            //}

            // PC movement
    
            Vector3 screenPosition = Input.mousePosition;
            screenPosition.z = Distance;

            Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);

            lookAtVector.x = Mathf.Clamp(worldPosition.x, -1.45f, 1.45f);


            parts[0].LookAt(lookAtVector);
            parts[0].Translate(new Vector3(0.0f, 0.0f, currentSpeed * Time.deltaTime));

            // Move snake tail

            if (parts.Count > 1)
            {
                for (int i = 1; i < parts.Count; i++)
                {
                    LipBody partComponent = parts[i - 1].GetComponent<LipBody>();
                    parts[i].position = partComponent.GetExPosition();
                    parts[i].rotation = partComponent.GetExRotation();
                }
            }

        
            
    }

    public void ThrowLips(GameObject LipDestroy)
    {
        parts.Remove(LipDestroy.transform);
    }


    public void DeleteLip(GameObject Lip)
    {
        parts.Remove(Lip.transform);
    }

    public void ShowLeaderBoard()
    {
        
        move = false;
        ScoreText.text = (transform.childCount - 1).ToString();
        LeaderBoard.SetActive(true);
    }







}

