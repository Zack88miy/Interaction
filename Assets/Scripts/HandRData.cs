using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HandRData : MonoBehaviour
{
    [SerializeField]
    private OVRSkeleton _ovrsr;

    [SerializeField]
    private OVRSkeleton _ovrsl;

    [SerializeField]
    private float angle = -45.0f;
    public Transform rwrist;
    public Transform lwrist;
    private Quaternion wrist;
    private Quaternion lwristq;
    public bool Flag = false;
    public Vector3 planeNormal = new Vector3(0,1,0);
    public GameObject palne;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = palne.GetComponent<MeshFilter>();
        Debug.Log("Setting angle : " + angle);
        Debug.Log(rwrist.forward);
        Mesh mesh = meshFilter.mesh;
        // Meshの法線ベクトルを取得
        Vector3[] normals = mesh.normals;
        Vector3 normalVector = normals[0];
        Debug.Log("Planeの法線ベクトル: " + normalVector);
        Debug.Log("Plane's Quatenrion:" + palne.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            Flag = !Flag;
        if(Flag)
            WristAngle();
            //WristData();
            //TestWrist();
    }

    public void TestWrist()
    {
        Quaternion baseq = Quaternion.Euler(0,0,0);
        Quaternion q1 = _ovrsr.Bones[(int) OVRSkeleton.BoneId.Hand_WristRoot].Transform.rotation;
        Vector3 v1 = _ovrsr.Bones[(int) OVRSkeleton.BoneId.Hand_WristRoot].Transform.position;
        //lwrist.rotation = Quaternion.AngleAxis(40,Vector3.forward) * q1;
        float res = Vector3.Angle(planeNormal,v1);
        float ang = res * Mathf.Rad2Deg;
        Debug.Log(res);
        Vector3 axis;
        float angle1;
        q1.ToAngleAxis(out angle1,out axis);
        Debug.Log("Angle: " + angle1);
        Debug.Log("Axis: " + axis);
    }

    public void WristData()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            angle += 5.0f;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            angle -= 5.0f;
        }
        
        Quaternion q1 = _ovrsr.Bones[(int) OVRSkeleton.BoneId.Hand_WristRoot].Transform.rotation;
        Quaternion q2 = _ovrsl.Bones[(int) OVRSkeleton.BoneId.Hand_WristRoot].Transform.rotation;

        lwrist.rotation = MultiplyQuatenrion(q1,q2);
    }

    Quaternion MultiplyQuatenrion(Quaternion q1,Quaternion q2)
    {
        Quaternion inverseQ1 = Quaternion.Inverse(q1);
        Quaternion diffQuaternion = inverseQ1 * q2;

        float angle;
        Vector3 axis;
        diffQuaternion.ToAngleAxis(out angle, out axis);

        Quaternion resultQuaternion = Quaternion.AngleAxis(angle, axis) * q1;

        return resultQuaternion;
    }

    public void WristAngle()
    {
        //Quaternion lwristq;
        Quaternion wrist;

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            angle += 5.0f;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            angle -= 5.0f;
        }
        wrist = _ovrsr.Bones[(int) OVRSkeleton.BoneId.Hand_WristRoot].Transform.rotation;  

        Quaternion rotation = wrist;
        Quaternion rotation180 = Quaternion.AngleAxis(angle,Vector3.forward);
        wrist = rotation180 * rotation;
    
        //lwristq = _ovrskeleton.Bones[(int)OVRSkeleton.BoneId.Hand_WristRoot].Transform.rotation;

        //lwristq = lwristq * rotation180;
        //lwrist.transform.position = lwrist.transform.position + new Vector3(minusx,0,0);
        lwrist.transform.rotation = wrist;
    }
}
