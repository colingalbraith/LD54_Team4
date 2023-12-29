using UnityEngine;
using UnityEngine.Video;

public class MiniGameManager : MonoBehaviour
{
    public bool miniGame1Completed = false;
    public bool miniGame2Completed = false;
    public VideoPlayer cutsceneVideoPlayer;

    public void MarkMiniGame1Completed()
    {
        miniGame1Completed = true;
        CheckBothMiniGamesCompleted();
    }

    public void MarkMiniGame2Completed()
    {
        miniGame2Completed = true;
        CheckBothMiniGamesCompleted();
    }

    private void CheckBothMiniGamesCompleted()
    {
        if (miniGame1Completed && miniGame2Completed)
        {
            PlayCutscene();
        }
    }

    private void PlayCutscene()
    {
        if (cutsceneVideoPlayer != null)
        {
            cutsceneVideoPlayer.Play();
        }
    }
}
