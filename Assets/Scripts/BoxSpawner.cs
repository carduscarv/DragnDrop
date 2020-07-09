using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSpawner : MonoBehaviour
{
    public ResultResources box;
    private GameObject boxClone;

    public GameObject boxPoolPos;

    private float deltaX, deltaY;

    private Vector2 mousePosition;

    private bool _hit;

    private string _title;
    private float distX = 0f;
    private float distY = 0f;

    private void Start() {
        _title = GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text;
        if(_title == "Algoritma-1"){
            distX = 3f;
            distY = 4.5f;
        }else{
            distX = 1.2f;
            distY = 1.2f;
        }
    }

    public void MouseClick(){
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    public void MouseDrag(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(boxClone == null){
            // Instantiate(gameObject, transform.position, Quaternion.identity);
            boxClone = Instantiate(box.actionObject, transform.position, Quaternion.identity);
            boxClone.transform.SetParent (GameObject.FindGameObjectWithTag("Respawn").transform, false);

        }
        
        boxClone.transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);

        if(Mathf.Abs(boxClone.transform.position.x - boxPoolPos.transform.position.x) <= distX && Mathf.Abs(boxClone.transform.position.y - boxPoolPos.transform.position.y) <= distY){
            _hit = true;
            boxPoolPos.GetComponent<BoxPool>().SetImageColor();
        }else{
            _hit = false;
        }

        

        if(!_hit){
            boxPoolPos.GetComponent<BoxPool>().ResetImageColor();   
        }
    }

    public void MouseUp(){
        if(Mathf.Abs(boxClone.transform.position.x - boxPoolPos.transform.position.x) <= distX && Mathf.Abs(boxClone.transform.position.y - boxPoolPos.transform.position.y) <= distY){
            BoxPool boxPool = boxPoolPos.GetComponent<BoxPool>();
            boxPool.SetToPool(box);
            // Destroy(gameObject);
        }
        _hit = false;
        boxPoolPos.GetComponent<BoxPool>().ResetImageColor();        
        Destroy(boxClone);       
        
    }



}
