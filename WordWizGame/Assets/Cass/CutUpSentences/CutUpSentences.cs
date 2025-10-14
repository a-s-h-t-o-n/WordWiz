using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CutUpSentences : MonoBehaviour
{
    //SENTENCES
    public List<string> lines;
    public CategoriesHandler categoriesHandler;

    //public int NumOfSentences = 3;

    //GRID/CANVAS AREA
    public RectTransform wordArea;
    public GameObject wordBox;
    public GameObject sentencePlacementArea;
    GridLayoutGroup grid;

    //SENTENCE
    public string fullSentence;
    public string[] words;
    public string[] shuffledWords;

    //RESULTS
    private bool correct = true;
    public GameObject answerImage;
    public TextMeshProUGUI answerText;
    public Button nextButton;
    public Button backButton;
    private TextMeshProUGUI textCheck;
    private Transform wordCheck;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        categoriesHandler = FindFirstObjectByType<CategoriesHandler>();
        lines = categoriesHandler.gameModeLines;
        grid = sentencePlacementArea.GetComponent<GridLayoutGroup>();
        SpawnNewSentence();

    }

    public void GenerateCutUpSentence()
    {
        //destroy old text boxes
        foreach (Transform child in wordArea)
        {
            Destroy(child.gameObject);
        }

        //get random sentence in file
        int randomSentenceNum = UnityEngine.Random.Range(0, lines.Count);
        fullSentence = lines[randomSentenceNum];

        //get random sentence and split into words
        words = fullSentence.Split(' ');

        //shuffledWords = words.;
        //System.Array.Copy(words, shuffledWords, words.Length);
        shuffledWords = (string[]) words.Clone();
        /*for(int i = 0; i < words.Length; i++)
        {
            shuffledWords[i] = words[i];
        }*/

        //shuffle words
        ShuffleWords(shuffledWords);

        //for each word generate a word box
        foreach (string word in shuffledWords)
        {
            GameObject newWordBox = Instantiate(wordBox, wordArea);
            TextMeshProUGUI text = newWordBox.GetComponentInChildren<TextMeshProUGUI>();
            text.text = word;
        }

        //}
    }

    private string[] ShuffleWords(string[] shuffledWords)
    {
        for (int i = 0; i < shuffledWords.Length; i++)
        {
            string temp = shuffledWords[i];
            int random = UnityEngine.Random.Range(i, shuffledWords.Length);
            shuffledWords[i] = shuffledWords[random];
            shuffledWords[random] = temp;
        }

        return shuffledWords;
    }

    //check the user input to the actual sentence
    public bool CheckCurrentSentence()
    {
        answerText.text = "CORRECT";

        //for the length of the actual sentence
        for (int i = 0; i < words.Length; i++)
        {
            //get the word slot
            wordCheck = grid.transform.GetChild(i);
            
            //if word slot == 0 aka no word box in the first slot, it is automatically wrong
            if(wordCheck.childCount == 0)
            {
                answerText.text = "INCORRECT";

                correct = false;
                break;
            }
            //get text from word box
            textCheck = wordCheck.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
           
            //if text at any point isn't the same as the sentence word, it's wrong
            if (textCheck.text != words[i])
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
            
            foreach(Transform child in space.transform)
            {
                Destroy(child.gameObject);
            }
        }
        GenerateCutUpSentence();
    }
}
