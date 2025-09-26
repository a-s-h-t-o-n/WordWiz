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
    [SerializeField] private List<TextMeshProUGUI> wordObjects;
    [SerializeField] private List<Area> areaList;

    private Image heldImage;
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
        if (heldImage != null)
        {
            if (heldImage)
            {
                heldImage.gameObject.transform.position = Input.mousePosition;
            }
        }
        
    }

    public void ToggleImageHold(Image image)
    {
        if (heldImage == null)
        {
            if (heldImage.GetComponent<WordOption>().occupiedArea != null)
            {
                heldImage.GetComponent<WordOption>().occupiedArea.imageHeld = null;
            }
            heldImage = image;
        }
        else
        {
            TryPlaceImage();
            heldImage = null;
        }
        
    }

    public void TryPlaceImage()
    {
        foreach (var area in areaList)
        {
            if (Vector3.Distance(heldImage.transform.position, area.transform.position) <= area.areaRadius)
            {
                heldImage.transform.position = area.transform.position;
                area.imageHeld = heldImage;
                heldImage.GetComponent<WordOption>().occupiedArea = area;
                return;
            }
        }
        
        WordOption word = heldImage.GetComponent<WordOption>();
        if (word)
        {
            heldImage.transform.position = word.startPos;
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
            wordObjects[i].text = spriteList[j].name.PartBefore('_');
        }
    }

    public void CheckAnswers()
    {
        int numCorrect = 0;
        for (int i = 0; i < areaList.Count; i++)
        {
            if (areaList[i].imageHeld != null && areaList[i].imageHeld.GetComponent<WordOption>().correctSprite == areaList[i].associatedSprite)
            {
                numCorrect++;
            }
        }
        
        Debug.Log($"YOU GOT {numCorrect} ANSWERS CORRECT");
    }
}
