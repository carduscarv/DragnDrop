using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public ResultResources box;
    private GameObject boxClone;

    public GameObject boxPoolPos;

    private float deltaX, deltaY;

    private Vector2 mousePosition;

    private bool _hit;

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

        if(Mathf.Abs(boxClone.transform.position.x - boxPoolPos.transform.position.x) <= 1.2f && Mathf.Abs(boxClone.transform.position.y - boxPoolPos.transform.position.y) <= 1.2f){
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
        if(Mathf.Abs(boxClone.transform.position.x - boxPoolPos.transform.position.x) <= 1.2f && Mathf.Abs(boxClone.transform.position.y - boxPoolPos.transform.position.y) <= 1.2f){
            BoxPool boxPool = boxPoolPos.GetComponent<BoxPool>();
            boxPool.SetToPool(box);
            // Destroy(gameObject);
        }
        _hit = false;
        boxPoolPos.GetComponent<BoxPool>().ResetImageColor();        
        Destroy(boxClone);       
        
    }



}
