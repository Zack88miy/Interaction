using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class GetRightMotion : MonoBehaviour
{
    [SerializeField]
    private OVRSkeleton _ovrskeleton;

    [SerializeField]
    private OVRSkeleton _ovrskeletonr;

    public DataToJson datatojson = new DataToJson();

    public CapturePose capturepose = new CapturePose();

    public bool loop = true;
    public List<BaseData> Bd ;

    
    public Transform blt0,blt1,blt2,blt3,blttip;
    public Transform bli1,bli2,bli3,blitip;
    public Transform blm1,blm2,blm3,blmtip;
    public Transform blr1,blr2,blr3,blrtip;
    public Transform blp0,blp1,blp2,blp3,blptip;
    public Transform lforearm;
    public Transform lwrist;

    public void Start()
    {

    }

    public void ResetData()
    {
        datatojson = new DataToJson();
    }

    public void RecordingData()
    {
        GetInfomation(OVRSkeleton.BoneId.Hand_WristRoot,
                          OVRSkeleton.BoneId.Hand_ForearmStub,
                          OVRSkeleton.BoneId.Hand_Thumb0,
                          OVRSkeleton.BoneId.Hand_Thumb1,
                          OVRSkeleton.BoneId.Hand_Thumb2,
                          OVRSkeleton.BoneId.Hand_Thumb3,
                          OVRSkeleton.BoneId.Hand_ThumbTip,
                          OVRSkeleton.BoneId.Hand_Index1,
                          OVRSkeleton.BoneId.Hand_Index2,
                          OVRSkeleton.BoneId.Hand_Index3,
                          OVRSkeleton.BoneId.Hand_IndexTip,
                          OVRSkeleton.BoneId.Hand_Middle1,
                          OVRSkeleton.BoneId.Hand_Middle2,
                          OVRSkeleton.BoneId.Hand_Middle3,
                          OVRSkeleton.BoneId.Hand_MiddleTip,
                          OVRSkeleton.BoneId.Hand_Ring1,
                          OVRSkeleton.BoneId.Hand_Ring2,
                          OVRSkeleton.BoneId.Hand_Ring3,
                          OVRSkeleton.BoneId.Hand_RingTip,
                          OVRSkeleton.BoneId.Hand_Pinky0,
                          OVRSkeleton.BoneId.Hand_Pinky1,
                          OVRSkeleton.BoneId.Hand_Pinky2,
                          OVRSkeleton.BoneId.Hand_Pinky3,
                          OVRSkeleton.BoneId.Hand_PinkyTip);
    }

    public void GetInfomation(params OVRSkeleton.BoneId[] boneids)
    {
        ThumbData thumb = new ThumbData(_ovrskeleton.Bones[(int)boneids[2]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[3]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[4]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[5]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[6]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[2]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[3]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[4]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[5]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[6]].Transform.rotation);

        IndexData index = new IndexData(_ovrskeleton.Bones[(int)boneids[7]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[8]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[9]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[10]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[7]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[8]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[9]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[10]].Transform.rotation);
        
        MiddleData middle = new MiddleData(_ovrskeleton.Bones[(int)boneids[11]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[12]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[13]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[14]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[11]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[12]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[13]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[14]].Transform.rotation);
        
        RingData ring = new RingData(_ovrskeleton.Bones[(int)boneids[15]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[16]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[17]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[18]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[15]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[16]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[17]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[18]].Transform.rotation);
        
        PinkyData pinky = new PinkyData(_ovrskeleton.Bones[(int)boneids[19]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[20]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[21]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[22]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[23]].Transform.position,
                                     _ovrskeleton.Bones[(int)boneids[19]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[20]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[21]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[22]].Transform.rotation,
                                     _ovrskeleton.Bones[(int)boneids[23]].Transform.rotation);

        Vector wrist = new Vector(_ovrskeleton.Bones[(int)boneids[0]].Transform.position.x,
                                 _ovrskeleton.Bones[(int)boneids[0]].Transform.position.y,
                                 _ovrskeleton.Bones[(int)boneids[0]].Transform.position.z);

        Quaternions wristq = new Quaternions(_ovrskeleton.Bones[(int)boneids[0]].Transform.rotation.x,
                                            _ovrskeleton.Bones[(int)boneids[0]].Transform.rotation.y,
                                            _ovrskeleton.Bones[(int)boneids[0]].Transform.rotation.z,
                                            _ovrskeleton.Bones[(int)boneids[0]].Transform.rotation.w);
        
        Vector arm = new Vector(_ovrskeleton.Bones[(int)boneids[1]].Transform.position.x,
                                 _ovrskeleton.Bones[(int)boneids[1]].Transform.position.y,
                                 _ovrskeleton.Bones[(int)boneids[1]].Transform.position.z);

        Quaternions armq = new Quaternions(_ovrskeleton.Bones[(int)boneids[1]].Transform.rotation.x,
                                            _ovrskeleton.Bones[(int)boneids[1]].Transform.rotation.y,
                                            _ovrskeleton.Bones[(int)boneids[1]].Transform.rotation.z,
                                            _ovrskeleton.Bones[(int)boneids[1]].Transform.rotation.w);
        

        BoneClass htable = new BoneClass(wrist,wristq,arm,armq,
                                         thumb,index,middle,ring,pinky);

        List<BoneClass> NewHandlist = new List<BoneClass>();
        NewHandlist.Add((BoneClass)htable.DeepCopy());

        BaseData bd = new BaseData(NewHandlist);

        datatojson.basedata.Add((BaseData)bd.DeepCopy());

    }

    //Save Hand Bone (json)
    public void SaveDataToFile()
    {
        string path = Application.dataPath + "/MotionCheckRData.json";

        if(File.Exists(@path))
           File.Delete(@path);
        
        using (var stream = new StreamWriter(path,false))
        {
            string jsonstr = JsonUtility.ToJson(datatojson);
            stream.Write(jsonstr);
        }

    }

    //Load Hand Bone (json)
    public void LoadDataToUnity()
    {
        string path = Application.dataPath + "/MotionCheckRData.json";

        datatojson.Clear();
        using (var steram = new StreamReader(path,false))
        {
            string datastr ="";
            datastr = steram.ReadToEnd();
            datatojson = JsonUtility.FromJson<DataToJson>(datastr);
            
        }
    }

    // Load Capture Data to Unity(From CaptureData.cs)
    public void LoadCaptureData()
    {
        string path = Application.dataPath + "/CapturePoseRData.json";

        capturepose.Clear();
        using (var steram = new StreamReader(path,false))
        {
            string datastr ="";
            datastr = steram.ReadToEnd();
            capturepose = JsonUtility.FromJson<CapturePose>(datastr);
            
        }
    }

    public void LoadDataToHands(int i)
    {
        int preframe = 0;
        int frameCount = datatojson.GetFrameCount;

        // Update Hand Data(next frame)
        if(i > 0)
        {
            if(i >= datatojson.GetFrameCount && loop)
                i %= frameCount;
            else if(i < 0 && loop)
                i += frameCount;

            preframe = i;
        }
                
        BaseData bd = datatojson.basedata[preframe];

        PoseData pd = capturepose.posedata[0];

        
        
        /* thumb finger */
        blt0.transform.rotation = new Quaternion(pd.Poses[0].td.t0rot.x,pd.Poses[0].td.t0rot.y,pd.Poses[0].td.t0rot.z,pd.Poses[0].td.t0rot.w);
        blt1.transform.rotation = new Quaternion(pd.Poses[0].td.t1rot.x,pd.Poses[0].td.t1rot.y,pd.Poses[0].td.t1rot.z,pd.Poses[0].td.t1rot.w);   
        blt2.transform.rotation = new Quaternion(pd.Poses[0].td.t2rot.x,pd.Poses[0].td.t2rot.y,pd.Poses[0].td.t2rot.z,pd.Poses[0].td.t2rot.w);   
        blt3.transform.rotation = new Quaternion(pd.Poses[0].td.t3rot.x,pd.Poses[0].td.t3rot.y,pd.Poses[0].td.t3rot.z,pd.Poses[0].td.t3rot.w);        
        blttip.transform.rotation = new Quaternion(pd.Poses[0].td.ttiprot.x,pd.Poses[0].td.ttiprot.y,pd.Poses[0].td.ttiprot.x,pd.Poses[0].td.ttiprot.w);
        
        /* index finger */
        bli1.transform.rotation = new Quaternion(pd.Poses[0].id.i1rot.x,pd.Poses[0].id.i1rot.y,pd.Poses[0].id.i1rot.z,pd.Poses[0].id.i1rot.w);
        bli2.transform.rotation = new Quaternion(pd.Poses[0].id.i2rot.x,pd.Poses[0].id.i2rot.y,pd.Poses[0].id.i2rot.z,pd.Poses[0].id.i2rot.w);
        bli3.transform.rotation = new Quaternion(pd.Poses[0].id.i3rot.x,pd.Poses[0].id.i3rot.y,pd.Poses[0].id.i3rot.z,pd.Poses[0].id.i3rot.w);
        blitip.transform.rotation = new Quaternion(pd.Poses[0].id.itiprot.x,pd.Poses[0].id.itiprot.y,pd.Poses[0].id.itiprot.z,pd.Poses[0].id.itiprot.w);

        /* middle finger */
        blm1.transform.rotation = new Quaternion(pd.Poses[0].md.m1rot.x,pd.Poses[0].md.m1rot.y,pd.Poses[0].md.m1rot.z,pd.Poses[0].md.m1rot.w);
        blm2.transform.rotation = new Quaternion(pd.Poses[0].md.m2rot.x,pd.Poses[0].md.m2rot.y,pd.Poses[0].md.m2rot.z,pd.Poses[0].md.m2rot.w);
        blm3.transform.rotation = new Quaternion(pd.Poses[0].md.m3rot.x,pd.Poses[0].md.m3rot.y,pd.Poses[0].md.m3rot.z,pd.Poses[0].md.m3rot.w);
        blmtip.transform.rotation = new Quaternion(pd.Poses[0].md.mtiprot.x,pd.Poses[0].md.mtiprot.y,pd.Poses[0].md.mtiprot.z,pd.Poses[0].md.mtiprot.w);
        
        /* ring finger */
        blr1.transform.rotation = new Quaternion(pd.Poses[0].rd.r1rot.x,pd.Poses[0].rd.r1rot.y,pd.Poses[0].rd.r1rot.z,pd.Poses[0].rd.r1rot.w);
        blr2.transform.rotation = new Quaternion(pd.Poses[0].rd.r2rot.x,pd.Poses[0].rd.r2rot.y,pd.Poses[0].rd.r2rot.z,pd.Poses[0].rd.r2rot.w);
        blr3.transform.rotation = new Quaternion(pd.Poses[0].rd.r3rot.x,pd.Poses[0].rd.r3rot.y,pd.Poses[0].rd.r3rot.z,pd.Poses[0].rd.r3rot.w);
        blrtip.transform.rotation = new Quaternion(pd.Poses[0].rd.rtiprot.x,pd.Poses[0].rd.rtiprot.y,pd.Poses[0].rd.rtiprot.z,pd.Poses[0].rd.rtiprot.w);
        
        /* pinky finger */
        blp0.transform.rotation = new Quaternion(pd.Poses[0].pd.p0rot.x,pd.Poses[0].pd.p0rot.y,pd.Poses[0].pd.p0rot.z,pd.Poses[0].pd.p0rot.w);
        blp1.transform.rotation = new Quaternion(pd.Poses[0].pd.p1rot.x,pd.Poses[0].pd.p1rot.y,pd.Poses[0].pd.p1rot.z,pd.Poses[0].pd.p1rot.w);
        blp2.transform.rotation = new Quaternion(pd.Poses[0].pd.p2rot.x,pd.Poses[0].pd.p2rot.y,pd.Poses[0].pd.p2rot.z,pd.Poses[0].pd.p2rot.w);
        blp3.transform.rotation = new Quaternion(pd.Poses[0].pd.p3rot.x,pd.Poses[0].pd.p3rot.y,pd.Poses[0].pd.p3rot.z,pd.Poses[0].pd.p3rot.w);
        blptip.transform.rotation = new Quaternion(pd.Poses[0].pd.ptiprot.x,pd.Poses[0].pd.ptiprot.y,pd.Poses[0].pd.ptiprot.z,pd.Poses[0].pd.ptiprot.w);

        lwrist.transform.rotation = new Quaternion(bd.Hands[0].wristrootrot.x,bd.Hands[0].wristrootrot.y,bd.Hands[0].wristrootrot.z,bd.Hands[0].wristrootrot.w);

        //lwrist.transform.position = new Vector3(bd.Hands[0].wristrootpos.x,bd.Hands[0].wristrootpos.y,bd.Hands[0].wristrootpos.z);
        //lforearm.transform.rotation = new Quaternion(bd.Hands[0].forearmstumbrot.x,bd.Hands[0].forearmstumbrot.y,bd.Hands[0].forearmstumbrot.z,bd.Hands[0].forearmstumbrot.w);
        //lforearm.transform.position = new Vector3(bd.Hands[0].forearmstumbpos.x,bd.Hands[0].forearmstumbpos.y,bd.Hands[0].forearmstumbpos.z);

    }

}
