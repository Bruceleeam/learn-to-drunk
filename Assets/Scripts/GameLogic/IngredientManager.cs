using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _notSelectedColor;
    public bool _selected = false;

    private void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ClickHandler);
    }

    public void ClickHandler()
    {
        if (!_selected)
        {
            _selected = true;
            GetComponent<Image>().color = _selectedColor;
            GameManager._userIngredients.Add(gameObject);
        }
        else
        {
            _selected = false;
            GetComponent<Image>().color = _notSelectedColor;
            GameManager._userIngredients.Remove(gameObject);
        }
    }

}