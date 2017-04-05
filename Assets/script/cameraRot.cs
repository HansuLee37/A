using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 


public class cameraRot : MonoBehaviour
{
    private Touch initTouch = new Touch();
    public Camera cam;
    public GameObject player;
    private float rotX = 0.0f;
    private float rotY = 0.0f;
    private Vector3 origRot;
    public float rotSpeed = 1.0f;
    public float dir = -1;
    private bool[] isOver = new bool[10];
    // Use this for initialization
    void Start()
    {
        rotSpeed = PlayerPrefs.GetFloat("Sen");
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
        for (int i = 0; i < 10; i++)
            isOver[i] = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rotSpeed = PlayerPrefs.GetFloat("Sen");
        for (int i = 9; i >= Input.touchCount; i--)
            isOver[i] = true;
        if (Input.touchCount> 0)
        {
            for(int i=0; i<Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (EventSystem.current.IsPointerOverGameObject(i) == false && isOver[i] == true)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        initTouch = touch;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        float deltaX = initTouch.position.x - touch.position.x;
                        float deltaY = initTouch.position.y - touch.position.y;
                        rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                        rotY += deltaX * Time.deltaTime * rotSpeed * dir;
                        rotX = Mathf.Clamp(rotX, -45f, 45f);
                        cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                        player.transform.rotation = Quaternion.Euler(player.transform.eulerAngles.x, cam.transform.eulerAngles.y, player.transform.eulerAngles.z);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        initTouch = new Touch();
                    }

                }
                else
                {
                    isOver[i] = false;
                }
            }
           
        }
    }
}
