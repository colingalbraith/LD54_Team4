using UnityEngine;
using System.Collections.Generic;

public class ObjectDeactivation : MonoBehaviour
{
    public List<GameObject> objectsToDeactivate;
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
            DeactivateObjects();
        }
    }

    private void DeactivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
