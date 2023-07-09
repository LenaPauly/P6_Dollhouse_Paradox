using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public GameObject amuletteNoLightObject;
    public GameObject FireObject;

    private void Start()
    {
        amuletteNoLightObject.SetActive(false);
        FireObject.SetActive(true);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Amulette")
        {
            Destroy(collision.gameObject);
            amuletteNoLightObject.SetActive(true);
            FireObject.SetActive(false);

        }
    }
}
