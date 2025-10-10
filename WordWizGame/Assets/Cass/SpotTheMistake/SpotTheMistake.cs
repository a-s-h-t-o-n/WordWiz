using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpotTheMistake : MonoBehaviour
{
    //SENTENCES
    public TextAsset sentencesFile;
    public string[] lines;

    //GRID/CANVAS AREA
    public RectTransform wordArea;
    public GameObject wordBox;
    GridLayoutGroup grid;

    //SENTENCE
    public string fullSentence;
    public string[] words;

    //RESULTS
    private bool correct = true;
    public GameObject answerImage;
    public TextMeshProUGUI answerText;
    public Button nextButton;
    public Button backButton;
    private TextMeshProUGUI textCheck;
    public Button selectedWord;
    public string mistake = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(sentencesFile.text);
        grid = wordArea.GetComponent<GridLayoutGroup>();
        SpawnNewSentence();
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

    public void SpawnNewSentence()
    {
        //hide previous result and next button
        answerImage.SetActive(false);
        nextButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);


        //remove all word boxes from previous sentence
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            Transform space = grid.transform.GetChild(i);

            foreach (Transform child in space.transform)
            {
                Destroy(child.gameObject);
            }
        }
        GenerateMistakeSentence();
    }

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

        for(int i = 0;i < words.Length; i++)
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

    }

    public bool CheckCurrentSentence()
    {
        answerText.text = "CORRECT";

        if(selectedWord == null)
        {
            answerText.text = "INCORRECT";

            correct = false;
        }
        else
        {
            textCheck = selectedWord.GetComponentInChildren<TextMeshProUGUI>();

            if (textCheck.text != mistake)
            {
                answerText.text = "INCORRECT";
                correct = false;
            }
        }

        //display next button and result
        answerImage.SetActive(true);
        nextButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        return correct;
    }
}
