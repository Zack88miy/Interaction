using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class ModeChangerV1 : MonoBehaviour
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
    public KeyCode SwitchHand = KeyCode.H;
    public KeyCode BackScene = KeyCode.O;

    public RecordState_ state = RecordState_.Stopped;

    private MotionCapture motioncapture;
    private CaptureData capturedata;
    private GetRightMotion getrightmotion;
    private CaptureRP capturerp;

    public Transform Plane;
    public GameObject tool;
    public GameObject tool_;

    [SerializeField]
    private float height = 0.02f;

    [SerializeField]
    private float depth = 0.02f;
    public int framecount = 0;

    private bool leftFlag = true;

    void Start()
    {
        motioncapture = GetComponent<MotionCapture>();
        capturedata = GetComponent<CaptureData>();
        getrightmotion = GetComponent<GetRightMotion>();
        capturerp = GetComponent<CaptureRP>();
    }

    void Update()
    {
        controlsGui.text = "";
        if(leftFlag)
        {
            tool.SetActive(true);
            tool_.SetActive(false);
        }else{
            tool.SetActive(false);
            tool_.SetActive(true);
        }

        switch(state)
        {
            case RecordState_.Stopped:
                framecount = 0;
                AllowBeginRecording();
                AllowBeginPlaying();
                AllowStartPositionSet();
                //BackHome();
                break;
            case RecordState_.Recording:
                if(leftFlag)
                    motioncapture.RecordingData();
                else
                    getrightmotion.RecordingData();
                AllowEndRecording();
                break;
            case RecordState_.Playing:
                if(leftFlag)
                    motioncapture.LoadDataToHands(framecount);
                else 
                    getrightmotion.LoadDataToHands(framecount);
                AllowStopPlaying();
                //AllowPausePlaying();
                framecount++;
                break;
            case RecordState_.Paused:
                AllowBeginPlaying();
                //AllowStopPlaying();               
                break;
            case RecordState_.Setting:
                if(leftFlag)
                    AllowCaptureLeftPose();
                else
                    AllowCaptureRightPose();
                AllowSwitchHand();
                AllowPositionChange();
                AllowSavePosition();
                break;
        }
        EndGame();

    }

    public void BackHome()
    {
        if(Input.GetKeyDown(BackScene))
        {
            SceneManager.LoadScene("HomeScene");
        }
    }

    // Estimate GrabPose 
    private void AllowCaptureLeftPose()
    {
        if(controlsGui != null)
        {
            //controlsGui.text += Capture + "- 手の形を記録する";
            //controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(Capture))
        {
            capturedata.ResetData();
            capturedata.CaptureList();
            Debug.Log("Save Estimate Capture Data");
        }
    }

    private void AllowCaptureRightPose()
    {
        if(controlsGui != null)
        {
            //controlsGui.text += Capture + "- 手の形を記録する";
            //controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(Capture))
        {
            capturerp.ResetData();
            capturerp.CaptureList();
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
            if(leftFlag)
                motioncapture.SaveDataToFile();
            else
                getrightmotion.SaveDataToFile();
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
            if(leftFlag)
            {
                motioncapture.LoadDataToUnity();
                motioncapture.LoadCaptureData();
            }else{
                getrightmotion.LoadDataToUnity();
                getrightmotion.LoadCaptureData();
            }
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
        Vector3 tpos;

        if(controlsGui != null)
        {
            //controlsGui.text += "↑↓ - 上下";
            //controlsGui.text += "←→ - 手前と奥行";
            //controlsGui.text += System.Environment.NewLine;
        }
        Vector3 plane_pos = Plane.position;
        if(leftFlag)
        {
            tpos = tool.transform.position;
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
            tool.transform.position = tpos;
        }  
        else
        {
            tpos = tool_.transform.position;
            if(Input.GetKeyDown(PositionUp))
            {
                plane_pos.y = Plane.transform.position.y + height;
                tpos.y = tool_.transform.position.y + height;
            }
            if(Input.GetKeyDown(PositionDown))
            {
                plane_pos.y = Plane.transform.position.y - height;
                tpos.y = tool_.transform.position.y - height;
            }
            if(Input.GetKeyDown(PositionFor))
            {
                plane_pos.z = Plane.transform.position.z + depth;
                tpos.z = tool_.transform.position.z + depth;
            }
            if(Input.GetKeyDown(PositionBack))
            {
                plane_pos.z = Plane.transform.position.z - depth;
                tpos.z = tool_.transform.position.z - depth;
            }
            tool_.transform.position = tpos;
        }
        Plane.position = plane_pos;
        
    }
    private void AllowSwitchHand()
    {
        if(controlsGui != null)
        {
            string sh = "";
            if(!leftFlag) sh = "右"; else sh ="左";
            controlsGui.text += "現在の麻痺側 : " + sh;
            controlsGui.text += System.Environment.NewLine;
            controlsGui.text += SwitchHand + "- 麻痺側を反対にする";
            controlsGui.text += System.Environment.NewLine;
        }
        if(Input.GetKeyDown(SwitchHand))
        {
            leftFlag = !leftFlag;
        }
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
        }
    }
    private void EndGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        }
    }
}
