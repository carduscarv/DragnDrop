using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Invertory : MonoBehaviour, IHasChanged
{
    [SerializeField]
    Transform slots;
    [SerializeField] 
    Text invertoryText;
    // Start is called before the first frame update
    void Start()
    {
        HasChanged();
    }

    public void HasChanged(){
        Debug.Log("Changed");
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");
        foreach(Transform slotTransform in slots){
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if(item){
                builder.Append(item.name);
                builder.Append(" - ");
            }
        }
        invertoryText.text = builder.ToString();
    }
}

namespace UnityEngine.EventSystems{
    public interface IHasChanged : IEventSystemHandler{
        void HasChanged();
    }
}
