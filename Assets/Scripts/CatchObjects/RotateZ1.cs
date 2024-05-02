using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ1 : MonoBehaviour
{
    public Rotate2 _rotate2;

    public float r1x,r1y,r1z;
    public GameObject another;

    void Start()
    {
        //_rotate2 = GetComponent<Rotate2>();
    }

    void Update()
    {
        //UpdateRotation();
        r1x = this.transform.eulerAngles.x;
        r1y = this.transform.eulerAngles.y;
        r1z = this.transform.eulerAngles.z;
        //Debug.Log("now r1x : " + this.transform.eulerAngles);
        another.GetComponent<RotateZ2>().BackSpin(r1x,r1y,r1z);
    }

    public void UpdateRotation()
    {
        
    }

}
