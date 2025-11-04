using System;
using TMPro;
using UnityEngine;

public class SentencesHandler : MonoBehaviour
{
    public TextAsset sentencesFile;
    public string[] lines;
    public string sentence;

    public string currentSentence;

    //WRITING WORD
    public TextMeshProUGUI wordMid;

    public bool front = true;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(sentencesFile.text);
        ReadWord();

    }

    private void Update()
    {
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

        for (int i = 0; i < 50; i++)
        {
            int randomLine = UnityEngine.Random.Range(0, lines.Length - 1);

            string line = lines[randomLine].Trim();
            if (line.StartsWith("-") && line.EndsWith("-"))
            {
                currentSentence = line.Trim('-', '-').Trim();
                break;
            }
        }
    }

    public void WriteWord()
    {
        wordMid.text = currentSentence;
    }

    public void NextClicked()
    {
        ReadWord();
    }
}
