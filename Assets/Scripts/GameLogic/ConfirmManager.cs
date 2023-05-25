using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Confirm);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._feedback)
            GetComponent<Button>().interactable = false;
        else
            GetComponent<Button>().interactable = true;
    }

    void Confirm()
    {
        GameManager.confirm = true;
    }

}
