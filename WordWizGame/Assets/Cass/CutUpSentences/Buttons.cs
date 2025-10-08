using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public CutUpSentences cutUpSentences;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        Debug.Log("clicking check");

        cutUpSentences.CheckCurrentSentence();
    }

    public void Next()
    {
        Debug.Log("clicking next");
        cutUpSentences.SpawnNewSentence();
    }

    public void Back()
    {
        SceneManager.LoadScene("Title");
    }
}
