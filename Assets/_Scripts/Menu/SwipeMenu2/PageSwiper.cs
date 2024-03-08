using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]private float _percentLimit = 0.2f;
    private Vector3 _panelLocation;
    private void Start()
    {
        _panelLocation = transform.position;

    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pressPosition - eventData.position);
        float difference = eventData.pressPosition.x - eventData.position.x;
        transform.position = _panelLocation - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //_panelLocation = transform.position;
        float percentage = (eventData.pressPosition.x - eventData.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= _percentLimit){
            Vector3 newLocation = _panelLocation;
            if(percentage > 0){
                newLocation += new Vector3(Screen.width, 0, 0);
            }else if(percentage < 0){
                newLocation -= new Vector3(Screen.width, 0, 0);
            }
            transform.position = newLocation;
            _panelLocation = newLocation;
        }else{
            transform.position = _panelLocation;
        }
    }
}
