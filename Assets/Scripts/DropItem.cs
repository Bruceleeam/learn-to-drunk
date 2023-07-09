using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public bool _fixed = true;

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.position = transform.position;
        if(eventData.pointerDrag.gameObject.tag == gameObject.tag)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<DragItem>()._fixed = _fixed;
        }
        else
        {

        }
    }

}