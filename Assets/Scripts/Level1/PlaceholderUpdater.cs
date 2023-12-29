using UnityEngine;
using TMPro;
using System.Collections;

public class PlaceholderUpdater : MonoBehaviour
{
    public TMP_Text currPlaceHolder;
    public string[] texts = {"[   ]", "[?  ]", "[?? ]", "[???]"};
    private int idx = 0;
    public float updateInterval = 1f;
    // Start is called before the first frame update
    
    private void Start()
    {
        StartCoroutine(UpdateTextRoutine());
    }

    private IEnumerator UpdateTextRoutine()
    {
        while (true)
        {
            currPlaceHolder.text = texts[idx];
            idx = (idx + 1) % texts.Length;
            yield return new WaitForSeconds(updateInterval);
        }
    }
}
