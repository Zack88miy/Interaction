using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public enum RecordState_
{
    Stopped = 0,
    Paused = 1,
    Recording = 2,
    Playing = 3,
    Setting = 4
}
public class RecordingController : MonoBehaviour
{
    public TextMesh controlsGui;

    [SerializeField]
    private OVRSkeleton _ovrskeleton;

    public KeyCode StartButton = KeyCode.S;
    public KeyCode StopButton = KeyCode.S;
    public KeyCode BeginPlay = KeyCode.P;
    public KeyCode PausePlaying = KeyCode.P;
    public KeyCode StopPlaying = KeyCode.J;
    public KeyCode PositionUp = KeyCode.UpArrow;
    public KeyCode PositionDown = KeyCode.DownArrow;
    public KeyCode PositionFor = KeyCode.RightArrow;
    public KeyCode PositionBack = KeyCode.LeftArrow;
    public KeyCode Capture = KeyCode.C;
    public KeyCode SettingMode = KeyCode.K;

    public RecordState_ state = RecordState_.Stopped;

    private MotionCapture motioncapture;
    private CaptureData capturedata;

    public Transform Plane;
    public Transform tool;

    [SerializeField]
    private float height = 0.02f;

    [SerializeField]
    private float depth = 0.02f;
    public int framecount = 0;

    void Start()
    {
        motioncapture = GetComponent<MotionCapture>();
        capturedata = GetComponent<CaptureData>();
    }

    void Update()
    {
        controlsGui.text = "";

        switch(state)
        {
            case RecordState_.Stopped:
                framecount = 0;
                AllowBeginRecording();
                AllowBeginPlaying();
                AllowStartPositionSet();
                break;
            case RecordState_.Recording:
                motioncapture.RecordingData();
                AllowEndRecording();
                break;
            case RecordState_.Playing:
                motioncapture.LoadDataToHands(framecount);
                AllowStopPlaying();
                AllowPausePlaying();
                framecount++;
                break;
            case RecordState_.Paused:
                AllowBeginPlaying();
                //AllowStopPlaying();               
                break;
            case RecordState_.Setting:
                AllowCapturePose();
                AllowPositionChange();
                AllowSavePosition();
                break;
        }

    }

    // Estimate GrabPose 
    private void AllowCapturePose()
    {
        if(controlsGui != null)
        {
            controlsGui.text += Capture + "- 手の形を記録する";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(Capture))
        {
            capturedata.ResetData();
            capturedata.CaptureList();
            Debug.Log("Save Estimate Capture Data");
        }
    }

    private void AllowBeginRecording()
    {
        if(controlsGui != null)
        {
            controlsGui.text += StartButton + "- 記録を始める";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(StartButton))
        {
            state = RecordState_.Recording;
            motioncapture.ResetData();
            Debug.Log("Start Recording");
        }
    }

    private void AllowEndRecording()
    {
        if(controlsGui != null)
        {
            controlsGui.text += StopButton + "- 記録を終わる";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(StopButton))
        {
            motioncapture.SaveDataToFile();
            state = RecordState_.Stopped;
            Debug.Log("Data Saved");
        }
    }

    private void AllowBeginPlaying()
    {
        if(controlsGui != null)
        {
            controlsGui.text += BeginPlay + "- 再生を始める";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(BeginPlay))
        {
            motioncapture.LoadDataToUnity();
            motioncapture.LoadCaptureData();
            state = RecordState_.Playing;
            Debug.Log("Start Playing");            
        }
    }
    
    private void AllowStopPlaying()
    {        
        if(controlsGui != null)
        {
            controlsGui.text += StopPlaying + "- 再生を停止する";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(StopPlaying))
        {
            state = RecordState_.Stopped;
        }
    }

    private void AllowPausePlaying()
    {        
        if(controlsGui != null)
        {
            controlsGui.text += BeginPlay + "- 一時停止する";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(PausePlaying))
        {
            state = RecordState_.Paused;
            motioncapture.LoadDataToHands(framecount);
        }
    }

    public void AllowPositionChange()
    {
        if(controlsGui != null)
        {
            controlsGui.text += "↑↓ - 上下";
            controlsGui.text += "←→ - 手前と奥行";
            controlsGui.text += System.Environment.NewLine;
        }
        Vector3 plane_pos = Plane.position;
        Vector3 tpos =  tool.position;
        if(Input.GetKeyDown(PositionUp))
        {
            plane_pos.y = Plane.transform.position.y + height;
            tpos.y = tool.transform.position.y + height;
        }
        if(Input.GetKeyDown(PositionDown))
        {
            plane_pos.y = Plane.transform.position.y - height;
            tpos.y = tool.transform.position.y - height;
        }
        if(Input.GetKeyDown(PositionFor))
        {
            plane_pos.z = Plane.transform.position.z + depth;
            tpos.z = tool.transform.position.z + depth;
        }
        if(Input.GetKeyDown(PositionBack))
        {
            plane_pos.z = Plane.transform.position.z - depth;
            tpos.z = tool.transform.position.z - depth;
        }
        Plane.position = plane_pos;
        tool.position = tpos;
    }

    private void AllowStartPositionSet()
    {
        if(controlsGui != null)
        {
            controlsGui.text += SettingMode + "- 各種調整を行う";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(SettingMode))
        {
            state = RecordState_.Setting;
        }
    }
    private void AllowSavePosition()
    {
        if(controlsGui != null)
        {
            controlsGui.text += SettingMode + "- 調整を終わる";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(SettingMode))
        {
            state = RecordState_.Stopped;
            Debug.Log(string.Format("Tool Positioin → x:{0} y:{1} z:{2}",tool.position.x,tool.position.y,tool.position.z));
        }
    }
}

[Serializable]
public class DataToJson
{
    public List<BaseData> basedata;

    public DataToJson()
    {
        basedata = new List<BaseData>();
    }

    public void Clear()
    {
        basedata.Clear();
    }

    public int GetFrameCount
    {
        get{return basedata.Count;}
    }
}


[Serializable]
public class BaseData
{
    public BaseData()
    {
        //Hands = new List<HandInformationV2>();
    }

    public BaseData(List<BoneClass> hi)
    {
        Hands = hi;
    }

    public List<BoneClass> Hands;

}