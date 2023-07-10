using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollAIManager : MonoBehaviour
{
   
    private void Start()
    {
        StartCoroutine(DollTimerCoroutine());
    }

    IEnumerator DollTimerCoroutine() //Starting the first conversation with the doll
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(20);

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        StartingAction();
        SpeechManager.StartSpeechRecording();

        yield return new WaitForSeconds(20);

        SpeechManager.StopSpeechRecording();
    }

    void StartingAction()
    {
        Debug.Log("Doll Voice Start");
    }
}
