using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private float h = 0.0f;
    private float v = 0.0f;
    public bool isRun = false;
    public bool isSit = false;
    private Transform tr;
    public float moveSpeed = 10.0f;
    public Camera cam;
    public joyStick joy;
	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
    public void Run()
    {
        isRun = !isRun;
    }
    // Update is called once per frame
    void Update () {
        if (isRun) moveSpeed = 15.0f;
        else moveSpeed = 10.0f;
        h = joy.Horizontal();
        v = joy.Vertical();
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
    }  
}
