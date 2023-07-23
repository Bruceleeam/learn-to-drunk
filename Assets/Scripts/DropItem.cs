using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    GameObject _lockedGO;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.gameObject.tag == gameObject.tag)
        {
            if (_lockedGO)
                UnhookOnDrop(_lockedGO);

            HookOnDrop(eventData.pointerDrag.gameObject);
        }
    }

    void HookOnDrop(GameObject go)
    {
        _lockedGO = go;
        go.transform.position = transform.position;
        go.GetComponent<DragItem>()._hooked = true;
        GameManager._userIngredients.Add(go);
    }

    void UnhookOnDrop(GameObject go)
    {
        go.transform.position = _lockedGO.GetComponent<DragItem>()._initPos;
        go.GetComponent<DragItem>().enabled = true;
        GameManager._userIngredients.Remove(go);
    }

}