using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonScript1 : MonoBehaviour
{
    private bool bullet1;
    private bool bullet2;

    // Start is called before the first frame update
    void Start()
    {
        bullet1 = true;
        bullet2 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick1()
    {
        bullet1 = true;
        bullet2 = false;
    }
}
