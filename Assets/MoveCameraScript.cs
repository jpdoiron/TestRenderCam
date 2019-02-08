﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    public ScreenRecorder myRecorder;
    public bool RandomizeLook = false;
    public float distanceMax = 2f;
    public float distanceMin = 2f;
    public float minHeight = 2f;

    public float LookMaxDelta = 4f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Rotation());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private IEnumerator Rotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.03f);
            Vector3 rand = (UnityEngine.Random.insideUnitSphere) * distanceMax;
            if (rand.magnitude < distanceMin)
            {
                rand.Normalize();
                rand *= distanceMin;
            }

            rand.y = Mathf.Abs(rand.y) + minHeight;
            transform.position = rand;
            float ld = UnityEngine.Random.Range(0, LookMaxDelta);
            transform.LookAt(new Vector3(0,1,0) + (RandomizeLook ? UnityEngine.Random.insideUnitSphere*ld:Vector3.zero));
            myRecorder.CaptureScreenshot();
        }
    }
}
