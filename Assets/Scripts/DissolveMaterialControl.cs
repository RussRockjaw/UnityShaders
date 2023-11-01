using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DissolveMaterialControl : MonoBehaviour
{
    private int pxWidth = 100, pxHeight = 100;
    private float xOrg = 0f, yOrg = 0f;
    private float scale = 10.0f;
    private Texture2D tex;
    private Color[] px;
    private Renderer rend;
    private  float step = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        tex = new Texture2D(pxWidth, pxHeight);
        px = new Color[tex.width * tex.height];
        rend.material.SetTexture("_DissolveTexture", tex);
        CalcNoise();
        StartCoroutine(AnimateDissolve());
    }

    //Create a random Perlin Noise texture and assign it to secondary texture slot
    void CalcNoise()
    {
        float y = 0.0f;
        while(y < tex.height)
        {
            float x = 0.0f;
            while(x < tex.width)
            {
                float xCoord = xOrg + x / tex.width * scale;
                float yCoord = yOrg + y / tex.height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                px[(int)y * tex.width + (int)x] = new Color(sample, sample, sample);
                x++;
            }
        y++;
        }
        tex.SetPixels(px);
        tex.Apply();
    }

    void Update()
    {
        
    }

    //Animate the dissolve shader for demo purposes.
    IEnumerator AnimateDissolve()
    {
        float time = 0.01f;
        while(true)
        {
            rend.material.SetFloat("_Amount", step);    //Increase this value to "dissolve the object
            step += time;

            if(step > 1f)
                step = 0f;

            yield return new WaitForSeconds(time);
        }
    } 
}
