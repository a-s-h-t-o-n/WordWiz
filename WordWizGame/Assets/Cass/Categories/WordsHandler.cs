using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordsHandler : MonoBehaviour
{
    public TextAsset wordsFile;
    public string[] lines;
    public string word;
    public string definition;

    public string currentWord;
    public string currentDefinition;

    //WRITING WORD
    public TextMeshProUGUI wordTop;
    public TextMeshProUGUI wordMid;
    public TextMeshProUGUI wordDefinition;

    public bool front = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(wordsFile.text);

    }

    private void Update()
    {
        ReadWord();
        WriteWord();
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

    public void ReadWord()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            if (line.StartsWith("-") && line.EndsWith("-"))
            {
                currentWord = line.Trim('-', '-').Trim();

                i++;
                currentDefinition = lines[i].Trim();
                break;
            }

        }
    }

    public void WriteWord()
    {
        wordTop.text = currentWord;
        wordMid.text = currentWord;
        wordDefinition.text = currentDefinition;

        if (front)
        {
            wordMid.gameObject.SetActive(true);
            wordTop.gameObject.SetActive(false);
            wordDefinition.gameObject.SetActive(false);
        }

        if (!front)
        {
            wordMid.gameObject.SetActive(false);
            wordTop.gameObject.SetActive(true);
            wordDefinition.gameObject.SetActive(true);
        }
    }

    public void Clicked()
    {
        if (front)
        {
            front = false;
        }
        else if (!front)
        {
            front = true;
        }
    }

}
