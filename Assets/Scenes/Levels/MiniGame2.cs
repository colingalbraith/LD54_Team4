using UnityEngine;

public class MiniGame2 : MonoBehaviour
{
    public MiniGameManager miniGameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            miniGameManager.MarkMiniGame2Completed();
        }
    }
}
