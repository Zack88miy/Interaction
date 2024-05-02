using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject HandleR,HandleL;
    public GameObject Joint;
    private Vector3 hr,hl,Jp;

    // Start is called before the first frame update
    void Start()
    {
        hr = HandleR.transform.position;
        hl = HandleL.transform.position;    
        Jp = Joint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleL.transform.position = hr;
            HandleR.transform.position = hl;
            Joint.transform.position = Jp;
            Debug.Log("Position Reset");
        }
    }
}
