using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CaptureRP : MonoBehaviour
{
    [SerializeField]
    private OVRSkeleton _ovrskeleton;

    public CapturePose capturepose = new CapturePose();

    public List<PoseData> pd;

    public void ResetData()
    {
        capturepose = new CapturePose();
    }
    public void CaptureList()
    {
        CaputreBoneData(OVRSkeleton.BoneId.Hand_WristRoot,
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

    public void CaputreBoneData(params OVRSkeleton.BoneId[] boneids)
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
        

        EstimatePose htable = new EstimatePose(wrist,wristq,arm,armq,
                                         thumb,index,middle,ring,pinky);

        List<EstimatePose> NewHandlist = new List<EstimatePose>();
        NewHandlist.Add((EstimatePose)htable.DeepCopy());

        PoseData pd = new PoseData(NewHandlist);

        capturepose.posedata.Add((PoseData)pd.DeepCopy());

        SaveCaptureData();
    }

    // Capture Pose Data to json file
    public void SaveCaptureData()
    {
        string path = Application.dataPath + "/CapturePoseRData.json";

        if(File.Exists(@path))
            File.Delete(@path);
        
        using (var stream = new StreamWriter(path,false))
        {
            string jsonstr = JsonUtility.ToJson(capturepose);
            stream.Write(jsonstr);
        }
    }
}
