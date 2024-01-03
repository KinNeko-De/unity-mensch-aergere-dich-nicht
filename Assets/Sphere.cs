using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Sphere: MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
                Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
