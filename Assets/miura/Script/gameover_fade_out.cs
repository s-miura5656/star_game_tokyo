using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class gameover_fade_out : MonoBehaviour
{
    // 透明化の速さ
    private float speed = 0.01f;
    // A値を操作するための変数
    private float alfa;
    // RGBを操作するための変数
    private float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Fadeout();
    }

    private void Fadeout()
    {
        if (alfa < 1)
        {
            alfa += speed;
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
        }
    }

    private void OnEnable()
    {
        alfa = 0f;
    }
}
