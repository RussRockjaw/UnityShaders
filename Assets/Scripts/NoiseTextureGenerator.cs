using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTextureGenerator : MonoBehaviour
{
    [SerializeField]private int pxWidth, pxHeight;
    [SerializeField]private float xOrg, yOrg;
    [SerializeField]private int scale = 1.0f;
    private Texture2D tex;
    private Color[] px;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        tex =new Texture2D(pxWidth, pxHeight);
        px = new Color[tex.width * tex.height];
        rend.material.mainTexture = tex;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
