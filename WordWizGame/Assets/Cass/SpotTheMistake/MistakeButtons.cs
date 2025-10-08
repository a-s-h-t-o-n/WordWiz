using UnityEngine;
using UnityEngine.SceneManagement;

public class MistakeButtons : MonoBehaviour
{
    public SpotTheMistake spotTheMistake;


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
}
