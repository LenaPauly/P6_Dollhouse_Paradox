using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCameras : MonoBehaviour
{
    // Start is called before the first frame update
    void start()
    {
        createMultidisplay();
    }
    void createMultidisplay()
    {
        Debug.Log("Hello");
        Debug.Log(Display.displays.Length);
        for (int i = 1; i < Display.displays.Length; i++)
            Display.displays[i].Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
