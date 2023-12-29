using UnityEngine;


public class FlickeringLight2D : MonoBehaviour
{
    public float minIntensity = 1f;  // Minimum light intensity
    public float maxIntensity = 5f;  // Maximum light intensity
    public float flickerSpeed = 1f;  // Speed of flickering
    public float flickerIntensityRange = 0.5f;  // Range for flickering intensity

    private UnityEngine.Rendering.Universal.Light2D light2DComponent;
    private float originalIntensity;

    void Start()
    {
        light2DComponent = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        originalIntensity = light2DComponent.intensity;
    }

    void Update()
    {
        // Calculate flickering intensity within the specified range
        float flickerIntensity = originalIntensity + Random.Range(-flickerIntensityRange, flickerIntensityRange);

        // Set the light intensity
        light2DComponent.intensity = flickerIntensity;

        // Wait for a short duration to create flickering effect
        float flickerDelay = 1f / flickerSpeed;
        Invoke("ResetIntensity", flickerDelay);
    }

    private void ResetIntensity()
    {
        // Reset light intensity to the original intensity
        light2DComponent.intensity = originalIntensity;
    }
}
