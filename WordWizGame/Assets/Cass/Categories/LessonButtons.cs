using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonButtons : MonoBehaviour
{
    public GameObject wordsLesson;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Words()
    {
        wordsLesson.SetActive(true);
    }

    public void CloseWords()
    {
        wordsLesson.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("Title");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Proceed()
    {
        SceneManager.LoadScene("GameModes");
    }
}
