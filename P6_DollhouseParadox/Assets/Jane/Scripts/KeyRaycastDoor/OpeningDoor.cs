using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            myAnimationController.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            myAnimationController.SetBool("isOpen", false);
        }
    }
}
