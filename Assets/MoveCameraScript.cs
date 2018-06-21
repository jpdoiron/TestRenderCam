using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    public ScreenRecorder myRecorder;

    public float distanceMax = 2f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Rotation());
    }

    private IEnumerator Rotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 rand = (UnityEngine.Random.insideUnitSphere).normalized * distanceMax;
            rand.y = Mathf.Abs(rand.y);
            transform.position = rand;
            transform.LookAt(new Vector3(0,1,0));
            myRecorder.CaptureScreenshot();
        }
    }
}
