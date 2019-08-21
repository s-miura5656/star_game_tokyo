using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_Manager : MonoBehaviour
{
    // HP関連
    public GameObject HP_text;
    [System.NonSerialized]
    public int tera_hp;

    // ENERGY関連
    public GameObject ENERGY_text;
    [System.NonSerialized]
    public int energy_count;

    // 残り弾数
    public GameObject remaining_bullet_text;
    [System.NonSerialized]
    public int bullet_count;

    // 残弾回復
    private float time;                       // 時間
    private float recharge_time = 10f;        // リチャージの時間


    // Start is called before the first frame update
    void Start()
    {
        tera_hp = 100;
        bullet_count = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Tera_HP();
        Energy_Gage();
        Bullet_Gage();
        Bullet_Charge();
    }

    private void Tera_HP()
    {
        Text hp_text = HP_text.GetComponent<Text>();
        hp_text.text = "HP:" + tera_hp;
    }

    private void Energy_Gage()
    {
        Text energy_text = ENERGY_text.GetComponent<Text>();
        energy_text.text = "ENERGY:" + energy_count;
    }

    private void Bullet_Gage()
    {
        Text energy_text = remaining_bullet_text.GetComponent<Text>();
        energy_text.text = "残弾:" + bullet_count;
    }

    private void Bullet_Charge()
    {
        if (bullet_count < 5)
        {
            time += Time.deltaTime;

            if (time >= recharge_time)
            {
                bullet_count += 1;
                time = 0f;
            }
        }
    }
}
