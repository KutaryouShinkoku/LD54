using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDelete : MonoBehaviour
{
    public Button btnDelete;
    // Start is called before the first frame update
    void Start()
    {
        btnDelete.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onClick()
    {

    }
}
