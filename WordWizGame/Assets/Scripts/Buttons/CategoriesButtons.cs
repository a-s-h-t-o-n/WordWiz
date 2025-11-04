using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoriesButtons : MonoBehaviour
{
    CategoriesHandler categoriesHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        categoriesHandler = FindFirstObjectByType<CategoriesHandler>();
    }
    public void GroceryStore()
    {
        categoriesHandler.chosenCategory = "GROCERY STORE";
        SceneManager.LoadScene("GroceryStoreLesson");
    }
    public void PersonalInfo()
    {
        categoriesHandler.chosenCategory = "PERSONAL INFORMATION";
        SceneManager.LoadScene("PersonalLesson");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("Title");
    }
}
