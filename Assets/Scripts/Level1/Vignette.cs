using UnityEngine;
using UnityEngine.UI;

public class VignetteController : MonoBehaviour
{
    public Image vignetteImage;
    public float minAlpha = 0.1f;
    public float maxAlpha = 0.3f;

    public float frequency = 1.0f;

    void Update()
    {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * frequency) + 1));
        vignetteImage.color = new Color(1, 0.4118f, 0.7059f, alpha); //pink
    }

    public void SetFrequency(float value)
    {
        frequency = value;
    }
    public void SetMinAlpha(float value)
    {
        minAlpha = value;
    }
    public void SetMaxAlpha(float value)
    {
        maxAlpha = value;
    }

}