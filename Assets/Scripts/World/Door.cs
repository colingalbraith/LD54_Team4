using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour
{
    public string nextSceneName;  // Name of the next scene to load
    public Image fadeImage;       // Image for the fade effect
    public float fadeDuration = 1.0f;

    private bool canInteract;      // Flag to check if the player can interact with the door
    private bool isFading;         // Flag to check if the scene is currently fading

    private Color startColor;      // Initial color of the fadeImage

    private void Start()
    {
        startColor = fadeImage.color;
        fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, 0);  // Set initial alpha to 0
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !isFading)
        {
            isFading = true;
            StartCoroutine(FadeAndLoadNextScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private IEnumerator FadeAndLoadNextScene()
    {
        float elapsedTime = 0f;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = endColor;

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
