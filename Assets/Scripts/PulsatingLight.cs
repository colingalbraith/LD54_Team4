using UnityEngine;
  // Import the Light2D namespace

public class PulsatingLight2D : MonoBehaviour
{
    public float minIntensity = 1f;  // Minimum light intensity
    public float maxIntensity = 5f;  // Maximum light intensity
    public float pulsateSpeed = 1f;  // Speed of pulsation

    private UnityEngine.Rendering.Universal.Light2D light2DComponent;

    void Start()
    {
        light2DComponent = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        // Calculate intensity based on a sine wave for pulsating effect
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * pulsateSpeed, 1f));

        // Set the light intensity
        light2DComponent.intensity = intensity;
    }
}
