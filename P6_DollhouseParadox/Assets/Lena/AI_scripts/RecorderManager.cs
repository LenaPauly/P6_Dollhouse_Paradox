using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RecorderManager : MonoBehaviour
{
    //drag this into the TransferMessage script in Inspector!!!

    SpeechManager speechmanager;
    public bool isRecorderActive = false;

    public string savedMessage = "";

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            SpeechManager.Instance.StopSpeechRecording();
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (savedMessage.Length >= 0)
            {
                SpeechManager.Instance.ReadOut(savedMessage); //all others will call this function, will get recieved string (message). will tell speechManager to read the string.
            }
            
        }
        startRecorderManager();
      // If the Button is pressed
      // start the first animation
      // Call the function from the other script and start it
      // after the script has been executed, set the boolean "startRecorder" to false
    }

    private void startRecorderManager()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            SpeechManager.Instance.startRecording();
            Debug.Log("speechmanager started");

        }

    }
    public void saveString(string message)
    {
        savedMessage = message;
        
    }
    
}
