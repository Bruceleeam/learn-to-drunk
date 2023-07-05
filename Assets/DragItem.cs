using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Color _dragColor;
    public bool _fixed = false;
    private Vector3 _initPos = new Vector3();

    private void Start()
    {
        _initPos = gameObject.transform.position;
        if (_itemImage == null)
            _itemImage = transform.GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = (Vector3)eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _itemImage.color = _dragColor;
        _itemImage.raycastTarget = false;
        transform.SetParent(GameObject.Find("Placeholders").transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _itemImage.color = Color.white;
        _itemImage.raycastTarget = true;
        if(!_fixed)
            transform.position = _initPos;
    }
}