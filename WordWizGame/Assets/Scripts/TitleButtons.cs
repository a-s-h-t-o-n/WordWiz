using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CutUpSentence()
    {
        SceneManager.LoadScene("GroceryStoreTest");
    }

    public void WordToImage()
    {
        SceneManager.LoadScene("ImageMatchScene");
    }

    public void MissingLetter()
    {
        SceneManager.LoadScene("MissingLetterScene");
    }
}
