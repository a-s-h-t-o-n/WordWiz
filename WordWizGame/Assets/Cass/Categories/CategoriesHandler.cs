using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CategoriesHandler : MonoBehaviour
{
    public TextAsset sentencesFile;
    public string[] lines;
    public string category;
    public string game;

    public string chosenCategory;
    public string chosenGame;
    public List<string> categoryLines;
    public List<string> gameModeLines;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(sentencesFile.text);

    }

    private void Update()
    {
        ReadCategory();
        ReadGameMode();
    }
    string[] SplitLines(string text)
    {
        if (text == null)
        {
            return null;
        }
        string[] lines = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        return lines;
    }

    List<string> ReadCategory()
    {
        categoryLines = new List<string>();
        string currentCategory = null;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            
            if (line.StartsWith("{") && line.EndsWith("}"))
            {
                currentCategory = line.Trim('{', '}').Trim();

                if(chosenCategory == currentCategory)
                {
                    i++;
                    while (lines[i].Trim() != "___")
                    {
                        categoryLines.Add(lines[i].Trim());
                        i++;
                    }
                    break;
                }
            }
            
        }
        return categoryLines;
    }

    List<string> ReadGameMode()
    {
        gameModeLines = new List<string>();
        string currentGameMode = null;

        for(int i = 0;i < categoryLines.Count; i++)
        {
            string line = categoryLines[i].Trim();

            if(line.StartsWith('-') && line.EndsWith('-'))
            {
                currentGameMode = line.Trim('-').Trim();
                if (chosenGame == currentGameMode)
                {
                    i++;
                    while (categoryLines[i].Trim() != "***")
                    {
                        gameModeLines.Add(categoryLines[i].Trim());
                        i++;
                    }
                    break;
                }
            }
        }
        return gameModeLines;
    }

    /*
    public void GenerateMistakeSentence()
    {
        //destroy old text boxes
        foreach (Transform child in wordArea)
        {
            Destroy(child.gameObject);
        }

        //get random sentence in file
        int randomSentenceNum = UnityEngine.Random.Range(0, lines.Length);
        fullSentence = lines[randomSentenceNum];

        //get random sentence and split into words
        words = fullSentence.Split(' ');


        foreach (string word in words)
        {
            if (word.StartsWith("*") && word.EndsWith("*"))
            {
                mistake = word.Trim('*');
            }
        }

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith("*") && words[i].EndsWith("*"))
            {
                words[i] = words[i].Trim('*');
            }
        }

        //for each word generate a word box
        foreach (string word in words)
        {
            GameObject newWordBox = Instantiate(wordBox, wordArea);
            TextMeshProUGUI text = newWordBox.GetComponentInChildren<TextMeshProUGUI>();
            text.text = word;
        }

    }*/
}
