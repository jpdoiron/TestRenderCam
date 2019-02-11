using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextureLoader : MonoBehaviour
{

    private string path = "./Wallpapers/";
    private FileInfo [] fileInfo;
    private List<string> filename;

    // Use this for initialization
    void Start()
    {
        filename = new List<string>();

        DirectoryInfo dir = new DirectoryInfo(path);

        fileInfo = dir.GetFiles("*.jpg");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        changeTexture();
    }

    void changeTexture()
    {

        int idx = Random.Range(0, fileInfo.Length - 1);

        Debug.Log("name:" + fileInfo[idx].FullName);

        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);

        WWW www = new WWW(fileInfo[idx].FullName);
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;

    }

}
