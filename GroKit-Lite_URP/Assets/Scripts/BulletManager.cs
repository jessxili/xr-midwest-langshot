using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnglishObjects
{
    apple,
    watermelon,
    bottle,
    orange,
    tomato
}

// Changed from struct to class
[System.Serializable] // Allows it to show in the Inspector
public class BulletMap
{
    public EnglishObjects english;
    public GameObject bullet;
    public GameObject targetObject; // Renamed from 'object' to avoid keyword conflict

    // Optional: Constructor for convenience
    public BulletMap(EnglishObjects english, GameObject bullet, GameObject targetObject)
    {
        this.english = english;
        this.bullet = bullet;
        this.targetObject = targetObject;
    }
}

public class BulletManager : MonoBehaviour
{
    public List<BulletMap> bulletManager = new List<BulletMap>(); // List of BulletMaps
    public GameManager gameManager;
    public Word[] words;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        words = gameManager.getWords();
    }


}
