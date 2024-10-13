using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

[System.Serializable]  // Make the class serializable
public class Word
{
    public string english;
    public string spanish;

    public Word(string e, string s)
    {
        english = e;
        spanish = s;
    }
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Word[] words;
    public Word[] selectedWords;
    private Random rand = new Random();

    /*
         public string[] spanishWords = { "libro", "manzana", "leche", "pan", "agua" };
     */

    public int currentWordIndex = 0;

    private void Start()
    {
        words = new Word[]
        {
            new Word("snack", "snack"),
            new Word("soda", "refresco"),
            new Word("chips", "papas fritas"),
            new Word("candy", "dulce"),
            new Word("gum", "chicle"),
            new Word("chocolate", "chocolate"),
            new Word("water bottle", "botella de agua"),
            new Word("sandwich", "sándwich"),
            new Word("fruit", "fruta"),
            new Word("ice cream", "helado"),
            new Word("coffee", "café"),
            new Word("tea", "té"),
            new Word("juice", "jugo"),
            new Word("energy drink", "bebida energética"),
            new Word("hot dog", "perrito caliente"),
            new Word("pizza slice", "trozo de pizza"),
            new Word("microwave meal", "comida para microondas"),
            new Word("breakfast bar", "barrita de desayuno"),
            new Word("pasta", "pasta"),
            new Word("frozen food", "comida congelada"),
        };

        selectedWords = words.OrderBy(w => rand.Next()).Take(10).ToArray();

    }
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void moveToNextWord()
    {
        currentWordIndex++;
        if (currentWordIndex >= selectedWords.Length)
        {
            selectedWords = words.OrderBy(w => rand.Next()).Take(10).ToArray();
        }
        else
        {
            Debug.Log("next word! " + selectedWords[currentWordIndex]);

        }
    }

    public string getCurrentSpanish()
    {
        return selectedWords[currentWordIndex].spanish;
    }
    public string getCurrentObjectTag()
    {
        return selectedWords[currentWordIndex].spanish;
    }
    public string getCurrentEnglishWord()
    {
        return selectedWords[currentWordIndex].english;
    }
    public Word[] getWords()
    {
        return words;
    }
}
