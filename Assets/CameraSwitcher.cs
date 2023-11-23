using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(cameras == null || cameras.Length == 0)
        {
            cameras = GameObject.FindObjectsOfType<Camera>();
        }


        if(cameras.Length > 0)
        {
            index = 0;
            
            for (int i=0; i< cameras.Length; i++)
            {
                if (cameras[i].tag == "MainCamera")
                    index = i;

                cameras[i].gameObject.SetActive(false);
            }

            DisableAllCameras();
            cameras[index].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cameras.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                DisableAllCameras();

                index++;
                if (index >= cameras.Length)
                    index = 0;

                cameras[index].gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                DisableAllCameras();
                
                index--;
                if (index < 0)
                    index = cameras.Length-1;

                cameras[index].gameObject.SetActive(true);
            }

        }
    }

    void DisableAllCameras()
    {
        foreach(Camera c in cameras)
        {
            c.gameObject.SetActive(false);
        }
    }
}
