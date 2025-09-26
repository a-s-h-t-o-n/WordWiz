using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ImageMatch : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private List<Image> imageObjects;
    [SerializeField] private List<WordOption> wordObjects;
    [SerializeField] private List<Area> areaList;

    private WordOption heldWord;
    public static Image overlappedArea;

    private List<Sprite> generatedImages = new List<Sprite>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
                heldWord.transform.position = area.transform.position;
                area.wordHeld = heldWord;
                heldWord.GetComponent<WordOption>().occupiedArea = area;
                return;
            }
        }
        
        WordOption word = heldWord.GetComponent<WordOption>();
        if (word)
        {
            heldWord.transform.position = word.startPos;
        }
        
    }

    public void GenerateImages()
    {
        for (int i = 0; i < 3; i++)
        {
            int j = Random.Range(0, spriteList.Count);
            generatedImages.Insert(i, spriteList[j]);
            areaList[i].associatedSprite = generatedImages[i];
            imageObjects[i].sprite = generatedImages[i];
            wordObjects[i].textMesh.text = spriteList[j].name.PartBefore('_');
            wordObjects[i].correctSprite = generatedImages[i];
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
        
        Debug.Log($"YOU GOT {numCorrect} ANSWERS CORRECT");
    }
}
