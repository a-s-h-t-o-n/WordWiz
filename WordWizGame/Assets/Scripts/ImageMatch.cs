using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ImageMatch : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private List<Image> imageObjects;
    [SerializeField] private List<WordOption> wordObjects;
    [SerializeField] private List<Area> areaList;

    [SerializeField] private Sprite debugSprite;

    private WordOption heldWord;
    public static Image overlappedArea;

    private List<Sprite> generatedImages = new List<Sprite>();

    [SerializeField] private ImageMatchSO groceryOptions;

    [SerializeField] private ImageMatchSO personalOptions;
    
    [SerializeField] private StarManager starManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CategoriesHandler catHandler = FindFirstObjectByType<CategoriesHandler>();
        if (catHandler != null)
        {
            if (catHandler.chosenCategory == "GROCERY STORE")
            {
                spriteList = groceryOptions.spriteOptions;
            }
            else if (catHandler.chosenCategory == "PERSONAL INFORMATION")
            {
                spriteList = personalOptions.spriteOptions;
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            generatedImages.Insert(i, debugSprite);
        }
        GenerateImages();
    }

    // Update is called once per frame
    void Update()
    {
        if (heldWord != null)
        {
            if (heldWord)
            {
                heldWord.gameObject.transform.position = Input.mousePosition;
            }
        }
        
    }

    public void ToggleImageHold(WordOption word)
    {
        if (heldWord == null)
        {
            heldWord = word;
            if (heldWord.occupiedArea != null)
            {
                heldWord.occupiedArea.wordHeld = null;
            }
        }
        else
        {
            TryPlaceImage();
            heldWord = null;
        }
        
    }

    public void TryPlaceImage()
    {
        foreach (var area in areaList)
        {
            
            if (Vector3.Distance(heldWord.transform.position, area.transform.position) <= area.areaRadius)
            {
                if (area.wordHeld != null) break;
                
                heldWord.transform.position = area.transform.position;
                area.wordHeld = heldWord;
                heldWord.GetComponent<WordOption>().occupiedArea = area;
                TextToSpeech.Instance.SpeakWord(heldWord.textMesh.text);
                return;
            }
        }
        
        if (heldWord)
        {
            heldWord.transform.position = heldWord.startPos;
        }
        
    }

    public void GenerateImages()
    {
        foreach (var word in wordObjects)
        {
            if (word)
            {
                word.correctSprite = null;
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            // select a random sprite, make sure it's not already being used
            int j = Random.Range(0, spriteList.Count);
            while (generatedImages.Contains(spriteList[j]))
            {
                j = Random.Range(0, spriteList.Count);
            }
            
            // assign sprite to relevant objects
            generatedImages[i] = spriteList[j];
            areaList[i].associatedSprite = generatedImages[i];
            imageObjects[i].sprite = generatedImages[i];


            
            // select a random word object, make sure it's not already used
            int k = Random.Range(0, 3);
            while (wordObjects[k].correctSprite != null)
            {
                k = Random.Range(0, 3);
            }
            wordObjects[k].textMesh.text = spriteList[j].name.PartBefore('_');
            wordObjects[k].correctSprite = generatedImages[i];
        }
    }

    public void CheckAnswers()
    {
        int numCorrect = 0;
        for (int i = 0; i < areaList.Count; i++)
        {
            if (areaList[i].wordHeld != null && areaList[i].wordHeld.correctSprite == areaList[i].associatedSprite)
            {
                numCorrect++;
            }
        }
        
        starManager.ShowResults(numCorrect);
        if (numCorrect > 0)
        {
            AudioManager.Instance.PlayCorrectSound();
        }
        else
        {
            AudioManager.Instance.PlayIncorrectSound();
        }
        Debug.Log($"YOU GOT {numCorrect} ANSWERS CORRECT");
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
