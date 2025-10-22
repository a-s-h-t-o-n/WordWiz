using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public class MissingLetter : MonoBehaviour
{
    public bool isDebug;
    private string word;
    private char letter;
    private List<char> letters = new List<char>{'0', '0', '0'};
    private int numOptions = 3;
    private TextMeshProUGUI selectedAnswer;
    private string wordWithGap;

    public GameObject helpVideo;
    public GameObject videoPlayer;

    // replace this w/ SO or similar data object
    private string[] words;

    [SerializeField] private MissingLetterSO groceryOptions;
    [SerializeField] private MissingLetterSO personalOptions;

    [SerializeField] private TextMeshProUGUI buttonText1, buttonText2, buttonText3, wordText1;

    [SerializeField] private StarManager starManager;

    private void Awake()
    {
        CategoriesHandler catHandle = FindFirstObjectByType<CategoriesHandler>();
        if (catHandle != null)
        {
            if (catHandle.chosenCategory == "GROCERY STORE")
            {
                words = groceryOptions.wordOptions.ToArray();
            }
            else if (catHandle.chosenCategory == "PERSONAL INFORMATION")
            {
                words = personalOptions.wordOptions.ToArray();
            }
        }
    }

    void Start()
    {
        
        GenerateRandomWord();
    }
    
    void Update()
    {
        
    }

    public void GenerateRandomWord()
    {
        int i = Random.Range(0, words.Length);
        word = words[i];
        
        GenerateMissingLetter();
    }

    public void GenerateMissingLetter()
    {
        letter = word[Random.Range(0, word.Length)];
        
        GenerateWrongLetters();
    }

    public void GenerateWrongLetters()
    {
        letters[0] = letters[1] = word[0];
        while (word.Contains(letters[0]))
        {
            letters[0] = (char)(122 - Random.Range(0, 25));
        }
        
        while (word.Contains(letters[1]))
        {
            letters[1] = (char)(122 - Random.Range(0, 25));
        }

        // add correct letter to letter option list
        letters[2] = letter;
        
        // Technically we should randomise, but sorting will achieve basically the same thing here. Alphabetical order won't give any indication as to which is correct.
        letters.Sort();

        SetUIElements();
    }

    private void SetUIElements()
    {
        buttonText1.GetComponentInParent<Image>().color = Color.white;
        buttonText2.GetComponentInParent<Image>().color = Color.white;
        buttonText3.GetComponentInParent<Image>().color = Color.white;
        buttonText1.text = letters[0].ToString();
        buttonText2.text = letters[1].ToString();
        buttonText3.text = letters[2].ToString();
        wordWithGap = word.Substring(0, word.IndexOf(letter)) + "_" + word.Substring(word.IndexOf(letter) + 1);
        wordText1.text = wordWithGap;
        
        if (isDebug) DedededeDebugItAll();
    }

    private void DedededeDebugItAll()
    {
        Debug.Log($"the word is {word}");
        Debug.Log($"the missing letter is {letter}");
        Debug.Log($"the letter options are {letters[0]} & {letters[1]} & {letters[2]}");
    }

    public void SetSelection(TextMeshProUGUI selection)
    {
        if (selectedAnswer != null)
        {
            selectedAnswer.transform.parent.GetComponent<Image>().color = Color.white; 
        }
        selectedAnswer = selection;
        selectedAnswer.transform.parent.GetComponent<Image>().color = Color.green;

        wordText1.text = wordWithGap.Replace('_', selectedAnswer.text[0]);

    }

    public void CheckSelection()
    {
        if (selectedAnswer != null && selectedAnswer.text == letter.ToString())
        {
            starManager.ShowResults(3);
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayCorrectSound();
                TextToSpeech.Instance.SpeakWord(word);
            }
            Debug.Log("RIGHT ANSWER.");
        }
        else
        {
            starManager.ShowResults(0);
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayIncorrectSound();
                TextToSpeech.Instance.SpeakWord(wordText1.text);
            }
            Debug.Log("WRONG ANSWER.");
        }
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Help()
    {
        helpVideo.SetActive(true);
        videoPlayer.SetActive(true);
    }

    public void ExitVideo()
    {
        helpVideo.SetActive(false);
        videoPlayer.SetActive(false);
    }
}
