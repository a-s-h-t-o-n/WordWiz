using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeButtons : MonoBehaviour
{
    CategoriesHandler categoriesHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        categoriesHandler = FindFirstObjectByType<CategoriesHandler>();
    }

    public void CutUpSentence()
    {
        categoriesHandler.chosenGame = "CUT UP SENTENCES";
        SceneManager.LoadScene("GroceryStoreTest");
    }

    public void SpotTheMistake()
    {
        categoriesHandler.chosenGame = "SPOT THE MISTAKE";
        SceneManager.LoadScene("SpotTheMistake");
    }

    public void WordToImage()
    {
        SceneManager.LoadScene("ImageMatchScene");
    }

    public void MissingLetter()
    {
        SceneManager.LoadScene("MissingLetterScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
