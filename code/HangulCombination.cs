using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Collections.LowLevel.Unsafe;

public class HangulCombination : MonoBehaviour
{
    private string row_chosung = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    private string row_jungsung = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private string row_jongsung = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
    // Start is called before the first frame update
    void Start()
    {
        string result = ResultKorean("ㅇ", "ㅝ", "ㄱ"); //읭
        Debug.Log(result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string ResultKorean(string chosung, string jungsung, string jongsung)
    {
        int chosungIndex = row_chosung.IndexOf((char)chosung[0]);
        int jungsungIndex = row_jungsung.IndexOf((char)jungsung[0]);
        int jongsungIndex = row_jongsung.IndexOf((char)jongsung[0]);

        //공식
        int result = ((chosungIndex * 588) + ((jungsungIndex * 28) + jongsungIndex)) + 44032;

        char temp = Convert.ToChar(result);
        return temp.ToString();
    }
}
