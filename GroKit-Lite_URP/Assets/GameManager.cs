using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

[System.Serializable]
public class Word
{
    public string english;
    public string spanish;

    public Word(string e, string s)
    {
        english = e;
        spanish = s;
    }

    public override string ToString() // Override ToString for better logging
    {
        return $"{english} - {spanish}";
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Word[] words;
    public Word[] selectedWords;
    private Random rand = new Random();

    public int currentWordIndex = 0;

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

    private void Start()
    {
        words = new Word[]
        {
            new Word("Pumpkin", "Calabaza"),
            new Word("Watermelon", "Sandía"),
            new Word("Tomato", "Tomate"),
            new Word("Apple", "Manzana"),
            new Word("Orange", "Naranja"),
            new Word("Cheese Box", "Caja de Queso"),
            new Word("Cheese", "Queso"),
            new Word("Bottle", "Botella"),
            new Word("Sausage", "Salchicha"),
            new Word("Bread", "Pan"),
            //new Word("ice cream", "helado"),
            //new Word("coffee", "café"),
            //new Word("tea", "té"),
            //new Word("juice", "jugo"),
            //new Word("energy drink", "bebida energética"),
            //new Word("hot dog", "perrito caliente"),
            //new Word("pizza slice", "trozo de pizza"),
            //new Word("microwave meal", "comida para microondas"),
            //new Word("breakfast bar", "barrita de desayuno"),
            //new Word("pasta", "pasta"),
            //new Word("frozen food", "comida congelada"),
        };

        selectedWords = words.OrderBy(w => rand.Next()).Take(10).ToArray();
        Debug.Log("START ");
        for (int i = 0; i < selectedWords.Length; i++)
        {
            Debug.Log(selectedWords[i]);
        }

    }

    public void moveToNextWord()
    {
        currentWordIndex++;
        if (currentWordIndex >= selectedWords.Length)
        {
            selectedWords = words.OrderBy(w => rand.Next()).Take(10).ToArray();
            currentWordIndex = 0;  // Reset the index after shuffling new words
            Debug.Log("Words reset");
            for (int i = 0; i < selectedWords.Length; i++)
            {
                Debug.Log(selectedWords[i].english);  // Display the new set of words
            }
        }
        else
        {
            Debug.Log("next word! " + selectedWords[currentWordIndex].english);
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
