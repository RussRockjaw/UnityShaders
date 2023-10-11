using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitheringEffect : MonoBehaviour
{
    public Material ditherMat;
    [Range(0.0f, 1.0f)]
    public float ditherStrength = 0.1f;
    [Range(1, 32)]
    public int colorDepth = 4;

    // Start is called before the first frame update
    void Awake()
    {
        ditherMat = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        ditherMat.SetFloat("_DitherStrength", ditherStrength);
        ditherMat.SetInt("_ColorDepth", colorDepth);
        Graphics.Blit(src, dest, ditherMat);
    }
}
