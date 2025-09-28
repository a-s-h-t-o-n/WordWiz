using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateWords : MonoBehaviour
{

    public TextAsset sentencesFile;
    public string[] lines;
    //public string category;
    //public string[] categories;
    public List<string> categories = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = SplitLines(sentencesFile.text);
        CheckCategory();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string[] SplitLines(string text)
    {
        if(text == null)
        {
            return null;
        }
        string[] lines = text.Split('\n');

        return lines;
    }

    void CheckCategory()
    {
        //string currentcategory = null;
        foreach (string line in lines)
        {
            if (line.StartsWith('-') && line.EndsWith('-'))
            {
                //categories = line.Split('-');
                //string category = line.Split('-').Select(p => p.Split('-'));
                //string category = line.Trim('-').Trim();
                //string category = line.Split('-');
                //categories.Add(line.Split('-'));

            }
        }
    }
}
