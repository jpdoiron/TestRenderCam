using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectPied : MonoBehaviour {

    public GameObject box;
	// Use this for initialization
	void Start () {
        /*
        Renderer[] mfs = GetComponentsInChildren<Renderer>();
        foreach (Renderer mf in mfs)
        {
            Vector3 pos = mf.transform.localPosition;
            Bounds child_bounds = mf.bounds ;
            child_bounds.extents *= mf.transform.localScale.x/2;
            Debug.Log(child_bounds.ToString());
            child_bounds.center += pos;
            bounds.Encapsulate(child_bounds);

        }
        box.transform.localScale = bounds.extents;
        box.transform.position = bounds.center;
        */
    }

    // Update is called once per frame
    public Rect ScrRect;
    private Vector3[] points = new Vector3[8];
    private Vector3[] screenPos = new Vector3[8];
    private Bounds bounds;

    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    public void UpdatePos()
    {

        Bounds b = box.GetComponent<Renderer>().bounds;
        points[0] = new Vector3(b.min.x, b.min.y, b.min.z);
        points[1] = new Vector3(b.max.x, b.min.y, b.min.z);
        points[2] = new Vector3(b.max.x, b.max.y, b.min.z);
        points[3] = new Vector3(b.min.x, b.max.y, b.min.z);
        points[4] = new Vector3(b.min.x, b.min.y, b.max.z);
        points[5] = new Vector3(b.max.x, b.min.y, b.max.z);
        points[6] = new Vector3(b.max.x, b.max.y, b.max.z);
        points[7] = new Vector3(b.min.x, b.max.y, b.max.z);

        Bounds screenBounds = new Bounds();
        for (int i = 0; i < 8; i++)
        {
            screenPos[i] = Camera.main.WorldToScreenPoint(points[i]);
            screenPos[i].y = Screen.height - screenPos[i].y;

            if (i == 0)
                screenBounds = new Bounds(screenPos[0], Vector3.zero);
            
            screenBounds.Encapsulate(screenPos[i]);
        }

        ScrRect.xMin = screenBounds.min.x;
        ScrRect.yMin = screenBounds.min.y;
        ScrRect.xMax = screenBounds.max.x;
        ScrRect.yMax = screenBounds.max.y;

        if (ScrRect.xMin < 0) ScrRect.xMin = 0;
        if (ScrRect.yMin < 0) ScrRect.yMin = 0;

        if (ScrRect.xMax > Screen.width) ScrRect.xMax = Screen.width;
        if (ScrRect.yMax > Screen.height) ScrRect.yMax = Screen.height;
        
        //Debug.Log(ScrRect);
        //ScrRect.yMin = Screen.height - screenBounds.max.y;
        //ScrRect.yMax = Screen.height - screenBounds.min.y;
    }


    void OnGUI()
    {
        //GUI.Box(ScrRect, "Area");


    }
}
