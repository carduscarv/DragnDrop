using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTransfer : MonoBehaviour
{
    // string penampung jawaban
    private string textSuara;
    private string textCahaya;
    private string textTombol;
    private string textSuhu;
    private string textLayar;

    // inputfield jawaban
    public Text inputFieldSuara;
    public Text inputFieldCahaya;
    public Text inputFieldSuhu;
    public Text inputFieldTombol;
    public Text inputFieldLayar;

    public GameObject panelPopup;
    public Text textPopup;

    public Button jawabBtn;

    private void Start() {
        jawabBtn.onClick.AddListener(AuthentificateText);
        panelPopup.SetActive(false);
    }

    // authentifikasi jawaban
    public void AuthentificateText(){
        // store input
        textSuara = inputFieldSuara.GetComponent<Text>().text;
        textSuhu = inputFieldSuhu.GetComponent<Text>().text;
        textCahaya = inputFieldCahaya.GetComponent<Text>().text;
        textTombol = inputFieldTombol.GetComponent<Text>().text;
        textLayar = inputFieldLayar.GetComponent<Text>().text;

        // jawaban
        string jawabanSuara = "bel masuk sekolah berbunyi";
        string jawabanSuhuA = "merasa kedinginan";
        string jawabanSuhuB = "kedinginan";
        string jawabanLayar = "komputer";
        string jawabanCahayaA = "terik matahari";
        string jawabanCahayaB = "matahari";
        string jawabanTombol = "menyalakan";

        int counter = 0;
        
        // authentifikasi jawaban, tidak case sensitif. asal string sesuai
        if(jawabanSuara.Equals(textSuara, StringComparison.OrdinalIgnoreCase)){
            Debug.Log("Jawaban benar!");
            counter++;
        }else{
            Debug.Log("Jawaban salah!");
        }

        if(jawabanSuhuA.Equals(textSuhu, StringComparison.OrdinalIgnoreCase) || jawabanSuhuB.Equals(textSuhu, StringComparison.OrdinalIgnoreCase)){
            Debug.Log("Jawaban benar!");
            counter++;
        }else{
            Debug.Log("Jawaban salah!");
        }

        if(jawabanCahayaA.Equals(textCahaya, StringComparison.OrdinalIgnoreCase) || jawabanCahayaB.Equals(textCahaya, StringComparison.OrdinalIgnoreCase)){
            Debug.Log("Jawaban benar!");
            counter++;
        }else{
            Debug.Log("Jawaban salah!");
        }

        if(jawabanLayar.Equals(textLayar, StringComparison.OrdinalIgnoreCase)){
            Debug.Log("Jawaban benar!");
            counter++;
        }else{
            Debug.Log("Jawaban salah!");
        }

        if(jawabanTombol.Equals(textTombol, StringComparison.OrdinalIgnoreCase)){
            Debug.Log("Jawaban benar!");
            counter++;
        }else{
            Debug.Log("Jawaban salah!");
        }

        panelPopup.SetActive(true);
        textPopup.text = String.Format("Jawaban anda benar {0} / 5", counter);
    }
}
