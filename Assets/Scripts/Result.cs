using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] Text result;
    [SerializeField] Text score;

    // Start is called before the first frame update
    void Start()
    {
        result.text = Define_Result();
        score.text = "You earned " + EventManager.finalScore + " points!";
    }

    string Define_Result()
    {
        if (EventManager.finalScore <= EventManager.EASY)
            return "You can do better!";
        else if (EventManager.finalScore <= EventManager.NORMAL)
            return "Not bad!";
        else if (EventManager.finalScore <= EventManager.HARD)
            return "Very good!";
        else
            return "Marvellous!";
    }
}
