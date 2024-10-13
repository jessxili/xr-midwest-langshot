using UnityEngine;

public class Testing : MonoBehaviour
{
    void Start()  // Unity will call this when the GameObject is initialized
    {
        test();  // Call the test method when the GameObject is initialized
    }

    void test()
    {
        for (int i = 0; i < 60; i++)
        {
            GameManager.Instance.moveToNextWord();
        }
    }
}
