using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRec : MonoBehaviour {
 
     AudioClip myAudioClip; 
     public bool recordingNew = false;
 
     void Start() {}
     void Update () {}
     
    void OnGUI()
    {

        GUIStyle myButtonStyle = new GUIStyle("button");
        myButtonStyle.fontSize = 35;
       // myButtonStyle.contentColor = Color.red;
        myButtonStyle.hover.textColor = Color.green;



         if (GUI.Button(new Rect(10,10,150,150),"Record",myButtonStyle))
     { 

         myAudioClip = Microphone.Start ( null, false, 10, 44100 );
     }
     if (GUI.Button(new Rect(10,175,150,150),"Send",myButtonStyle))
     {
     	recordingNew = true;
         SavWav.Save("myfile", myAudioClip);
 
 //        audio.Play();
         }
    }
 }
