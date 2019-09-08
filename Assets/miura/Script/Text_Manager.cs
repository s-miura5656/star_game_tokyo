using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_Manager : MonoBehaviour
{
    [SerializeField] // 残り弾数 前左
    private GameObject remaining_bullet_front_L_text;
    [SerializeField] // 残り弾数 前右
    private GameObject remaining_bullet_front_R_text;
    [SerializeField] // 残り弾数 後左
    private GameObject remaining_bullet_back_L_text;
    [SerializeField] // 残り弾数 後右
    private GameObject remaining_bullet_back_R_text;

    [System.NonSerialized]
    public int bullet_count_front_L;
    [System.NonSerialized]
    public int bullet_count_front_R;
    [System.NonSerialized]
    public int bullet_count_back_L;
    [System.NonSerialized]
    public int bullet_count_back_R;

    // 残弾回復
    private float time;                       // 時間
    private float recharge_time = 10f;        // リチャージの時間


    // Start is called before the first frame update
    void Start()
    {
        bullet_count_front_L = 15;
        bullet_count_front_R = 15;
        bullet_count_back_L = 5;
        bullet_count_back_R = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Bullet_Gage_Front_L();
        Bullet_Gage_Front_R();
        Bullet_Gage_Back_L();
        Bullet_Gage_Back_R();
    }

    private void Bullet_Gage_Front_L()
    {
        Text gage_text = remaining_bullet_front_L_text.GetComponent<Text>();
        gage_text.text = "残弾:" + bullet_count_front_L;
    }

    private void Bullet_Gage_Front_R()
    {
        Text gage_text = remaining_bullet_front_R_text.GetComponent<Text>();
        gage_text.text = "残弾:" + bullet_count_front_R;
    }

    private void Bullet_Gage_Back_L()
    {
        Text gage_text = remaining_bullet_back_L_text.GetComponent<Text>();
        gage_text.text = "残弾:" + bullet_count_back_L;
    }

    private void Bullet_Gage_Back_R()
    {
        Text gage_text = remaining_bullet_back_R_text.GetComponent<Text>();
        gage_text.text = "残弾:" + bullet_count_back_R;
    }

    public void bullet_front_L_out()
    {
        bullet_count_front_L -= 1;
    }

    public void bullet_front_R_out()
    {
        bullet_count_front_R -= 1;
    }

    public void bullet_back_L_out()
    {
        bullet_count_back_L -= 1;
    }

    public void bullet_back_R_out()
    {
        bullet_count_back_R -= 1;
    }

    private void OnEnable()
    {
        bullet_count_front_L = 15;
        bullet_count_front_R = 15;
        bullet_count_back_L = 5;
        bullet_count_back_R = 5;
    }
}
