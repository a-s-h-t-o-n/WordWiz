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

    public GameObject sentencePlacementArea;
    GridLayoutGroup grid;
    public string fullSentence;
    public string[] words;

    bool correct = true;
    public GameObject answerImage;
    public TextMeshProUGUI answerText;
    public Button nextButton;

    public TextMeshProUGUI textCheck;
    public Transform wordCheck;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(sentencesFile.text);
        grid = sentencePlacementArea.GetComponent<GridLayoutGroup>();
        SpawnNewSentence();

    }

    // Update is called once per frame
    void Update()
    {
        //CheckCurrentSentence();

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateCutUpSentence();
        }*/
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
        foreach (Transform child in wordArea)
        {
            Destroy(child.gameObject);
        }

        //get random sentence in file
        int randomSentenceNum = Random.Range(0, lines.Length);
        fullSentence = lines[randomSentenceNum];

        //get random sentence and split into words
        words = fullSentence.Split(' ');

        //for each word generate a word box
        foreach (string word in words)
        {
            GameObject newWordBox = Instantiate(wordBox, wordArea);
            TextMeshProUGUI text = newWordBox.GetComponentInChildren<TextMeshProUGUI>();
            text.text = word;
        }

        //}
    }


    public bool CheckCurrentSentence()
    {
        //string checkSentence = "";
        answerText.text = "RIGHT";


        //get word in grid layout of sentence placement
        //check for all word in sentence that grid layout words == sentence words

        //for all in the grid

        for (int i = 0; i < words.Length; i++)
        {
            wordCheck = grid.transform.GetChild(i);

            if(wordCheck.childCount > 0)
        {
            textCheck = wordCheck.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            if (textCheck == null || wordCheck == null)
            {
                answerText.text = "WRONG";
                correct = false;
                break;
            }

            if (textCheck.text != words[i])
            {
                answerText.text = "WRONG";
                correct = false;
            }
        }

            
            //checkSentence += textCheck.text + " ";
        }

            
        answerImage.SetActive(true);
        nextButton.gameObject.SetActive(true);
        return correct;
    }

    public void SpawnNewSentence()
    {
        answerImage.SetActive(false);
        nextButton.gameObject.SetActive(false);

        for(int i = 0; i < grid.transform.childCount; i++)
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
