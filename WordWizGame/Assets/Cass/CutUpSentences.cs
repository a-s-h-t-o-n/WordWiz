using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CutUpSentences : MonoBehaviour
{
    public TextAsset sentencesFile;
    public string[] lines;
    
    //public int NumOfSentences = 3;
    
    //PREFAB
    public GameObject wordBox;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(sentencesFile.text);
        GenerateCutUpSentences();

    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void GenerateCutUpSentences()
    {
        foreach (string line in lines) {
            string fullSentence = line;
            string[] words = line.Split(' ');
            foreach (string word in words)
            {
                GameObject newWordBox = Instantiate(wordBox, this.transform);
                TextMeshProUGUI text = newWordBox.GetComponentInChildren<TextMeshProUGUI>();
                text.text = word;
            }
        }
    }

}
