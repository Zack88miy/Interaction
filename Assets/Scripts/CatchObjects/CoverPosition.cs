using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverPosition : MonoBehaviour
{
    public GameObject coverobject;
    Vector3 firstposition;
    // Start is called before the first frame update
    void Start()
    {
        firstposition = coverobject.transform.position;
        Vector3 firstrotation = coverobject.transform.eulerAngles;
        //Debug.Log("CoverR first position : " + firstposition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowposition = coverobject.transform.position;
        //Debug.Log("CoverR now position : " + nowposition);
        if(nowposition.x >= 0.2)
            coverobject.transform.position = firstposition;
    }
}
