using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform lipManager;
    private float cameraOffset;
    float offset = -6.0f;

    void Start()
    {
        cameraOffset = offset;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, lipManager.GetChild(0).position.z + cameraOffset);
    }
}

