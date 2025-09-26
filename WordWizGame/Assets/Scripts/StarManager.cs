using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    [SerializeField] private Sprite starGold;
    [SerializeField] private Sprite starGrey;
    [SerializeField] private List<Image> stars;
    
    
    [SerializeField] private GameObject resultObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResults(int numStars)
    {
        resultObject.SetActive(true);

        foreach (Image star in stars)
        {
            if (numStars > 0)
            {
                star.sprite = starGold;
                numStars--;
            }
            else
            {
                star.sprite = starGrey;
            }
        }
    }
}
