using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class BoneClass 
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

    public BoneClass(Vector Wp,Quaternions Wr,Vector Fp,Quaternions Fr,
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

[Serializable]
public class ThumbData
{
    public Vector T0pos,T1pos,T2pos,T3pos,T_tippos;
    public Quaternions t0rot,t1rot,t2rot,t3rot,ttiprot;

    public ThumbData(Vector3 T0,Vector3 T1, Vector3 T2,Vector3 T3,Vector3 Ttip,
                     Quaternion t0, Quaternion t1, Quaternion t2, Quaternion t3, Quaternion ttip)
    {
        T0pos = new Vector(T0.x,T0.y,T0.z);
        T1pos = new Vector(T1.x,T1.y,T1.z);
        T2pos = new Vector(T2.x,T2.y,T2.z);
        T3pos = new Vector(T3.x,T3.y,T3.z);
        T_tippos  = new Vector(Ttip.x,Ttip.y,Ttip.z);
        t0rot = new Quaternions(t0.x,t0.y,t0.z,t0.w);
        t1rot = new Quaternions(t1.x,t1.y,t1.z,t1.w);
        t2rot = new Quaternions(t2.x,t2.y,t2.z,t2.w);
        t3rot = new Quaternions(t3.x,t3.y,t3.z,t3.w);
        ttiprot = new Quaternions(ttip.x,ttip.y,ttip.z,ttip.w);
    }
}

[Serializable]
public class IndexData
{
    public Vector I1pos,I2pos,I3pos,I_tippos;
    public Quaternions i1rot,i2rot,i3rot,itiprot;

    public IndexData(Vector3 T1, Vector3 T2,Vector3 T3,Vector3 Ttip,
                     Quaternion t1, Quaternion t2, Quaternion t3, Quaternion ttip)
    {
        I1pos = new Vector(T1.x,T1.y,T1.z);
        I2pos = new Vector(T2.x,T2.y,T2.z);
        I3pos = new Vector(T3.x,T3.y,T3.z);
        I_tippos  = new Vector(Ttip.x,Ttip.y,Ttip.z);
        i1rot = new Quaternions(t1.x,t1.y,t1.z,t1.w);
        i2rot = new Quaternions(t2.x,t2.y,t2.z,t2.w);
        i3rot = new Quaternions(t3.x,t3.y,t3.z,t3.w);
        itiprot = new Quaternions(ttip.x,ttip.y,ttip.z,ttip.w);
    }
}

[Serializable]
public class MiddleData
{
    public Vector M1pos,M2pos,M3pos,M_tippos;
    public Quaternions m1rot,m2rot,m3rot,mtiprot;

    public MiddleData(Vector3 T1, Vector3 T2,Vector3 T3,Vector3 Ttip,
                     Quaternion t1, Quaternion t2, Quaternion t3, Quaternion ttip)
    {
        M1pos = new Vector(T1.x,T1.y,T1.z);
        M2pos = new Vector(T2.x,T2.y,T2.z);
        M3pos = new Vector(T3.x,T3.y,T3.z);
        M_tippos  = new Vector(Ttip.x,Ttip.y,Ttip.z);
        m1rot = new Quaternions(t1.x,t1.y,t1.z,t1.w);
        m2rot = new Quaternions(t2.x,t2.y,t2.z,t2.w);
        m3rot = new Quaternions(t3.x,t3.y,t3.z,t3.w);
        mtiprot = new Quaternions(ttip.x,ttip.y,ttip.z,ttip.w);
    }
}

[Serializable]
public class RingData
{
    public Vector R1pos,R2pos,R3pos,R_tippos;
    public Quaternions r1rot,r2rot,r3rot,rtiprot;

    public RingData(Vector3 T1, Vector3 T2,Vector3 T3,Vector3 Ttip,
                     Quaternion t1, Quaternion t2, Quaternion t3, Quaternion ttip)
    {
        R1pos = new Vector(T1.x,T1.y,T1.z);
        R2pos = new Vector(T2.x,T2.y,T2.z);
        R3pos = new Vector(T3.x,T3.y,T3.z);
        R_tippos  = new Vector(Ttip.x,Ttip.y,Ttip.z);
        r1rot = new Quaternions(t1.x,t1.y,t1.z,t1.w);
        r2rot = new Quaternions(t2.x,t2.y,t2.z,t2.w);
        r3rot = new Quaternions(t3.x,t3.y,t3.z,t3.w);
        rtiprot = new Quaternions(ttip.x,ttip.y,ttip.z,ttip.w);
    }
}

[Serializable]
public class PinkyData
{
    public Vector P0pos,P1pos,P2pos,P3pos,P_tippos;
    public Quaternions p0rot,p1rot,p2rot,p3rot,ptiprot;

    public PinkyData(Vector3 T0,Vector3 T1, Vector3 T2,Vector3 T3,Vector3 Ttip,
                     Quaternion t0, Quaternion t1, Quaternion t2, Quaternion t3, Quaternion ttip)
    {
        P0pos = new Vector(T0.x,T0.y,T0.z);
        P1pos = new Vector(T1.x,T1.y,T1.z);
        P2pos = new Vector(T2.x,T2.y,T2.z);
        P3pos = new Vector(T3.x,T3.y,T3.z);
        P_tippos  = new Vector(Ttip.x,Ttip.y,Ttip.z);
        p0rot = new Quaternions(t0.x,t0.y,t0.z,t0.w);
        p1rot = new Quaternions(t1.x,t1.y,t1.z,t1.w);
        p2rot = new Quaternions(t2.x,t2.y,t2.z,t2.w);
        p3rot = new Quaternions(t3.x,t3.y,t3.z,t3.w);
        ptiprot = new Quaternions(ttip.x,ttip.y,ttip.z,ttip.w);
    }
}

[Serializable]
public class Quaternions
{
    public float x;
    public float y;
    public float z;
    public float w;

    public Quaternions(float x,float y,float z,float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }
}

[Serializable]
public class Vector
{
    public float x;
    public float y;
    public float z;

    public Vector(float x,float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
