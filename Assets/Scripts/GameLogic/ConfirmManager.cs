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
        
    }

    void Confirm()
    {
        GameManager.confirm = true;
    }

}
