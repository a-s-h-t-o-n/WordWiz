using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CutUpSentences : MonoBehaviour
{
    public TextAsset sentencesFile;
    public string[] lines;
    
    public int NumOfSentences = 3;

    public RectTransform wordArea;
    
    //PREFAB
    public GameObject wordBox;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(sentencesFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        TestCurrentSentence();
    }

    string[] SplitLines(string text)
    {
        if (text == null)
        {
            return null;
        }
        string[] lines = text.Split('\n');

        return lines;
    }

    public void GenerateCutUpSentence()
    {
        //destroy old text boxes
        foreach(Transform child in wordArea)
        {
            Destroy(child.gameObject);
        }

        //get random sentence in file
        int randomSentenceNum = Random.Range(0, lines.Length);
        string fullSentence = lines[randomSentenceNum];
        
        //get random sentence and split into words
        string[] words = fullSentence.Split(' ');

        //for each word generate a word box
        foreach (string word in words)
        {
            GameObject newWordBox = Instantiate(wordBox, wordArea);
            TextMeshProUGUI text = newWordBox.GetComponentInChildren<TextMeshProUGUI>();
            text.text = word;
        }


        //}
    }

    void TestCurrentSentence()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateCutUpSentence();
        }
    }

}
