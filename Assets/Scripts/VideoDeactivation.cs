using UnityEngine;

public class VideoDeactivation : MonoBehaviour
{
    public GameObject videoObject;
    public float deactivationTime = 10.0f;

    private float currentTime;

    void Start()
    {
        currentTime = 0.0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= deactivationTime)
        {
            DeactivateVideoObject();
        }
    }

    private void DeactivateVideoObject()
    {
        if (videoObject != null)
        {
            videoObject.SetActive(false);
        }
    }
}
