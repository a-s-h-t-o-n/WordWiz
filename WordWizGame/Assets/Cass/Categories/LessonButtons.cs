using UnityEngine;

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
}
