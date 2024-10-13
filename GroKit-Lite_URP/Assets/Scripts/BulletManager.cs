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

public class BulletManager : MonoBehaviour
{
    public void SetObjectFalse() {
        Debug.Log("hallo!!");
        Destroy(gameObject);
        
    }   
}
