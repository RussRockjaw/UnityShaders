using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TileTextureManager : MonoBehaviour
{
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = this.gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
       material.SetFloat("_Width", this.transform.localScale.x);
       material.SetFloat("_Height", this.transform.localScale.y);
    }
}
