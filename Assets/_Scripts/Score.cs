using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Score : MonoBehaviour
{
    public static int PinCount;
    [SerializeField] private TextMeshProUGUI text;
    public int startCount;

    public GameObject gameOverMenuIU;


    void Start()
    {
        PinCount = startCount;
        text = GetComponent<TextMeshProUGUI>();
   
    }

    void Update()
    {
       text.text = PinCount.ToString();
    }

 }

