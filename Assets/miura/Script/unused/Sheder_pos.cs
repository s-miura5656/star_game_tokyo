using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheder_pos : MonoBehaviour
{
    private MaterialPropertyBlock p;

    private Material mat = null;

    private Renderer rend = null;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        this.mat = rend.material;
        p = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        p.Clear();
        p.SetVector("_ObjectPosition", this.transform.position);

        rend.SetPropertyBlock(p);
    }
}
