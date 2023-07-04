using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraints : MonoBehaviour
{
    Rigidbody rb;
    public bool Constrain = false;

     void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
        if (Constrain)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX |
                                                    RigidbodyConstraints.FreezePositionY |
                                                    RigidbodyConstraints.FreezePositionZ |
                                                    RigidbodyConstraints.FreezeRotationX |
                                                    RigidbodyConstraints.FreezeRotationZ;

        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
    }
}
