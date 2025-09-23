using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissingLetter : MonoBehaviour
{
    public bool isDebug;
    private string word;
    private char letter;
    private List<char> letters = new List<char>();

    // replace this w/ SO or similar data object
    private string[] words = { "egg", "apple", "shoe", "bee", "flower", "tree", "rock", "juice", "colour", "fruit", "meat", "food" };

    [SerializeField] private TextMeshProUGUI buttonText1, buttonText2, buttonText3, wordText1;
    
    void Start()
    {
        GenerateRandomWord();
    }

    // Update is called once per frame
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
        letters.Insert(0, word[0]); 
        letters.Insert(1, word[0]);
        
        while (word.Contains(letters[0]))
        {
            letters[0] = (char)(122 - Random.Range(0, 25));
        }
        
        while (word.Contains(letters[1]))
        {
            letters[1] = (char)(122 - Random.Range(0, 25));
        }

        // add correct letter to letter option list
        letters.Insert(2, letter);
        
        // Technically we should randomise, but sorting will achieve basically the same thing here. Alphabetical order won't give any indication as to which is correct.
        letters.Sort();

        SetUIElements();
    }

    public void SetUIElements()
    {
        buttonText1.text = letters[0].ToString();
        buttonText2.text = letters[1].ToString();
        buttonText3.text = letters[2].ToString();
        wordText1.text = word.Replace(letter, '_');
        
        if (isDebug) DebugDebugItAll();
    }

    private void DebugDebugItAll()
    {
        Debug.Log($"the word is {word}");
        Debug.Log($"the missing letter is {letter}");
        Debug.Log($"the letter options are {letters[0]} & {letters[1]} & {letters[2]}");
    }
}
