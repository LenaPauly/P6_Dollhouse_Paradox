using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public GameObject amuletteNoLightObject;

    private void Start()
    {
        amuletteNoLightObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Amulette")
        {
            Destroy(collision.gameObject);
            amuletteNoLightObject.SetActive(true);

        }
    }
}
