using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class EstimatePose
{
    public ThumbData td;
    public IndexData id;
    public MiddleData md;
    public RingData rd;
    public PinkyData pd;

    public Vector wristrootpos;
    public Quaternions wristrootrot;
    public Vector forearmstumbpos;
    public Quaternions forearmstumbrot;

    public EstimatePose(Vector Wp,Quaternions Wr,Vector Fp,Quaternions Fr,
                    ThumbData Th,IndexData Id,MiddleData Md,RingData Rd,PinkyData Pd)
    {
        wristrootpos = Wp;
        wristrootrot = Wr;
        forearmstumbpos = Fp;
        forearmstumbrot = Fr;
        td = Th;
        id = Id;
        md = Md;
        rd = Rd;
        pd = Pd;
        
    }
}
