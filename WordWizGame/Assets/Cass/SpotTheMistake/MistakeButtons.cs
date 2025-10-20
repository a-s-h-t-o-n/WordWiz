using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MistakeButtons : MonoBehaviour
{
    public SpotTheMistake spotTheMistake;

    public GameObject helpVideo;
    public GameObject videoPlayer;
    public void Check()
    {
        Debug.Log("clicking check");

        spotTheMistake.CheckCurrentSentence();
    }

    public void Next()
    {
        Debug.Log("clicking next");
        spotTheMistake.SpawnNewSentence();
    }

    public void Back()
    {
        SceneManager.LoadScene("Title");
    }

    public void Help()
    {
        helpVideo.SetActive(true);
        videoPlayer.SetActive(true);
    }

    public void ExitVideo()
    {
        helpVideo.SetActive(false);
        videoPlayer.SetActive(false);
    }
}
