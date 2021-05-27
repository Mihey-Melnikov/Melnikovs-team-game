using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayText : MonoBehaviour
{
    private static Text gameObject;
    private static Canvas canvas;
    public static bool isContinuation;
    
    private void Start()
    {
        gameObject = GameObject.Find("Text").GetComponent<Text>();
        canvas = GameObject.Find("Chat").GetComponent<Canvas>();
        isContinuation = false;
    }

    private void Update()
    {
        if (!isContinuation && Input.GetKeyDown(KeyCode.Space))
        {
            canvas.sortingOrder = -1;
        }
    }

    public static void UpdateText(string text)
    {
        canvas.sortingOrder = 5;
        gameObject.text = text;
    }
}
