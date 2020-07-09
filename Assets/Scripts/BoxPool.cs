using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxPool : MonoBehaviour
{
    // List penampung gerakan (bergerak, mengambil, looping)
    private List<ResultResources> boxList;
    // List penampung gerakan temporary (digunakan untuk logic loopinh)
    private List<ResultResources> tmpActionMoves;
    // Index untuk jumlah aksi yang dapat ditampung di pool
    private int _count = -1;
    // Gameobject penampung object yg ditanam dalam pool
    GameObject _boxes;
    // Object gambar & warna yang diubah saat resource aksi memasuki wilayah pool
    private Image colors;  
    private Color imageColorToBeUsed;
    
    private string _title;

    private string _rightAnswer;

    // Button referensi move dan reset
    public Button jawabBtn;
    public Button resetBtn;

    public GameObject panelPopup;
    public Text textPopup;

    

    // Start is called before the first frame update
    void Start()
    {
        // inisialisasi
        boxList = new List<ResultResources>();   
        colors = GetComponent<Image>();
        // movePoint = new Point(0, 0);
        // buat event listener untuk button move dan reset
        jawabBtn.onClick.AddListener(CheckMoves);
        resetBtn.onClick.AddListener(ResetMoves);
        panelPopup.SetActive(false);

        _title = GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text;
        if(_title == "Algoritma-1"){
            _rightAnswer = "1234567";
        }else{
            _rightAnswer = "1234";
        }
    }

    // Fungsi saat button moves dipanggil, check apakah ada gerakan didalam pool
    private void CheckMoves(){
        string answer = "";
        if(boxList.Count == gameObject.transform.childCount-1){
            for (int i = 0; i < boxList.Count; i++)
            {
                answer = answer + boxList[i].answer;
            }
            
            if(answer == _rightAnswer){
                Debug.Log("Jawaban benar");
                textPopup.text = "Jawaban Anda Benar!";
            }else{
                Debug.Log("Jawaban salah");
                textPopup.text = "Jawaban Anda Salah!";
            }
            panelPopup.SetActive(true);
        }else{
            Debug.Log("Pindahkan semua kotak");
            ResetMoves();
        }
    }

    // Logic memasukan resource gerakan kedalam pool, terutama bagian looping
    public void SetToPool(ResultResources moves){
        if(_count < gameObject.transform.childCount-2){
            _count++;
            boxList.Add(moves);

            // Buat object di dalam pool sesuai dengan resource aksi yang dipanggil
            _boxes = Instantiate(boxList[_count].actionObject, transform.position, Quaternion.identity);
            _boxes.transform.SetParent (GameObject.FindGameObjectWithTag("Pool").transform, false);
            _boxes.transform.position = gameObject.transform.GetChild(_count).transform.position;
        }
        
    }

    // Fungsi saat button reset dipanggil, hapus semua yg ada dalam pool
    private void ResetMoves(){
        foreach (Transform child in GameObject.FindGameObjectWithTag("Pool").transform) {
            Destroy(child.gameObject);
            ResetPoolCounter();
        }
    }

    // reset list dan object di dalam pool, ubah kondisi ke tidak bisa bergerak
    public void ResetPoolCounter(){
        _count = -1;
        boxList.Clear();
    }

    // Set warna gambar
    public void SetImageColor(){
        imageColorToBeUsed.a = 0.8f;
        imageColorToBeUsed.r = 1f;
        imageColorToBeUsed.g = 0.86f;
        imageColorToBeUsed.b = 0.62f;
        colors.color = imageColorToBeUsed;
    }

    // Reset warna gambar (default)
    public void ResetImageColor(){
        imageColorToBeUsed.a = 0.6f;
        imageColorToBeUsed.r = 1f;
        imageColorToBeUsed.g = 1f;
        imageColorToBeUsed.b = 1f;
        colors.color = imageColorToBeUsed;
    }
}
