using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollSpeech : MonoBehaviour
{

    [SerializeField] GameObject doll;
    private Collider triggerCollider;
    private AudioSource speaker;
    public GameObject secondDoll;

    private void Start()
    {
        triggerCollider = GetComponent<Collider>();
        speaker = GetComponent<AudioSource>();
        secondDoll.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerCollider != other)
        {
            StartCoroutine(PlayAudioAndDestroy());
            Destroy(triggerCollider);
            Debug.Log("started coroutine, destroyed trigger");
        }
    }

    private IEnumerator PlayAudioAndDestroy()
    {
        // Play the audio
        speaker.Play();

        // Wait for the audio to finish playing
        yield return new WaitForSeconds(speaker.clip.length);

        // Call a function or perform any other desired action
        DestroyObjects();
        SecondDollActive(); 


        // Update is called once per frame
        void DestroyObjects()
        {
            Destroy(doll);
            Destroy(speaker.gameObject);
        }
        void SecondDollActive()
        {
            secondDoll.SetActive(true);
        }
    }
}
