using System;
using System.Collections.Generic;
using UnityEngine;

public class WordsHandler : MonoBehaviour
{
    public TextAsset wordsFile;
    public string[] lines;
    public string word;
    public string definition;

    public string currentWord;
    public string currentDefinition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(wordsFile.text);

    }

    private void Update()
    {
        ReadWord();
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
}
