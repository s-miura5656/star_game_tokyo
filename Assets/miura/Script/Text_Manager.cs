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

    // Start is called before the first frame update
    void Start()
    {
        tera_hp = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Tera_HP();
        Energy_Gage();
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
}
