using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ2 : MonoBehaviour
{
    public float r2x,r2y,r2z;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BackSpin(float x,float y,float z)
    {
        //Debug.Log("BackSpin Success");
        Transform thisTransform = this.transform;
        thisTransform.rotation = Quaternion.Euler(x,y,-z);
        //Debug.Log("now r2x : " + thisTransform.eulerAngles);
    }
}
