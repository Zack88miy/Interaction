using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour
{
    //public Rotate2 _rotate2;

    public float r1x,r1y,r1z;
    public GameObject another;
    public Vector3 firstrot; 

    void Start()
    {
        //_rotate2 = GetComponent<Rotate2>();
        firstrot = this.transform.eulerAngles;
        //Debug.Log("First Rotation : " + firstrot);
    }

    void Update()
    {
        //UpdateRotation();
        r1x = this.transform.eulerAngles.x;
        r1y = this.transform.eulerAngles.y;
        r1z = this.transform.eulerAngles.z;
        //Debug.Log("now r1x : " + this.transform.eulerAngles);
        another.GetComponent<Rotate2>().BackSpin(r1x,r1y,r1z);
    }

    public void UpdateRotation()
    {
        
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        this.transform.eulerAngles = new Vector3(firstrot.x,firstrot.y,firstrot.z);
        //Debug.Log("Reset Rotation : " + this.transform.eulerAngles);
    }*/

}
