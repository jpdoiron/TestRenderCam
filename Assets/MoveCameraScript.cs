using System;
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
	public int nbPoints = 1024;
	protected System.Random localRand;

    // Use this for initialization
    void Start()
    {
		Vector3[] points = PointsOnHemisphere (nbPoints);
		localRand = new System.Random ((int)DateTime.Now.Ticks & 0x0000FFFF);
		StartCoroutine(Rotation(points));
    }

    // Update is called once per frame
    void Update()
    {

    }

	Vector3[] PointsOnHemisphere(int nbPoints) 
	{
		Vector3[] upts = new Vector3[nbPoints];
		float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
		float off = 1.0f/nbPoints;
		float phi, x, y, z, r = 0.0f;

		for (int k = 0; k < nbPoints; ++k) 
		{
			y = (k * off) - 1 + (off /2);
			r = Mathf.Sqrt(1 - y * y);

			phi = k * inc;
			x = Mathf.Cos(phi) * r;
			z = Mathf.Sin(phi) * r;

			upts[k] = new Vector3(x, Math.Abs(y), z);
		}
		return upts;
	}


	private IEnumerator Rotation(Vector3[] v)
    {
		for (int i = 0; i < v.Length; ++i)
        //while (true)
        {
            yield return new WaitForSeconds(0.03f);
			/*float x = (float)((localRand.NextDouble() * 2.0) - 1.0);
			float y = (float)localRand.NextDouble();
			float z = (float)((localRand.NextDouble() * 2.0) - 1.0);*/
			float dist = Math.Max (distanceMin, (float)localRand.NextDouble () * (distanceMax - distanceMin));



			Vector3 randx = Vector3.Normalize(v[i]) * dist;
			//Vector3 randx = Vector3.Normalize(new Vector3(x, y, z)) * dist;
			//Vector3 randx = UnityEngine.Random.onUnitSphere * dist;
            transform.position = randx;


            
            transform.LookAt(new Vector3(0,0,0) + (RandomizeLook ? UnityEngine.Random.insideUnitSphere:Vector3.zero));
            myRecorder.CaptureScreenshot();
        }
    }
}
