using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_hole_missile_manager : MonoBehaviour
{
    // プレハブのミサイルを入れるオブジェクト
    private GameObject missile;              
    // ミサイルの複製用オブジェクト
    private GameObject missile_copy;         
    // ミサイルコントローラーを入れるスクリプト
    private missile_controller script;       
    // テキストマネージャーの取得
    [SerializeField]
    private GameObject text_manager;         
    // テキストマネージャーのスクリプトの取得
    private Text_Manager text_script;        
    // 次弾撃てるまでの時間
    private float relord_time = 0f;          
    // 時間
    private float time;                      
    // ミサイルを発射してるかしてないか
    private bool missile_shot;
    // ミサイルの発射を決める数字の入っている変数
    private int missile_start_number;
    // ミサイルの発射地点
    private Vector3 missile_start_pos;
    // 戦艦後ろ右のオブジェクトを取得
    [SerializeField]
    private GameObject Ship_Back_R;
    // 戦艦後ろ左のオブジェクトを取得
    [SerializeField]
    private GameObject Ship_Back_L;
    // 戦艦前右のオブジェクトを取得
    [SerializeField]
    private GameObject Ship_Front_R;
    // 戦艦前左のオブジェクトを取得
    [SerializeField]
    private GameObject Ship_Front_L;
    // ミサイルを撃つか撃たないかのステート
    private bool Missile_shot_state;
    // 戦艦の位置を入れるための変数
    private Vector3 Ship_Back_R_pos;
    private Vector3 Ship_Back_L_pos;
    private Vector3 Ship_Front_R_pos;
    private Vector3 Ship_Front_L_pos;
    // 戦艦のスクリプトを取得
    private Ship_destroy script_back_R;
    private Ship_destroy script_back_L;
    private Ship_destroy script_front_R;
    private Ship_destroy script_front_L;
    // シーンマネージャーオブジェクトの取得
    [SerializeField]
    private GameObject scene_manager;
    private scene_manager scene_script;
    // Start is called before the first frame update
    void Start()
    {
        missile = (GameObject)Resources.Load("Missile");
        script = missile.GetComponent<missile_controller>();
        text_script = text_manager.GetComponent<Text_Manager>();
        Ship_Back_L_pos = Ship_Back_L.transform.position;
        Ship_Back_R_pos = Ship_Back_R.transform.position;
        Ship_Front_L_pos = Ship_Front_L.transform.position;
        Ship_Front_R_pos = Ship_Front_R.transform.position;
        script_back_R = Ship_Back_R.GetComponent<Ship_destroy>();
        script_back_L = Ship_Back_L.GetComponent<Ship_destroy>();
        script_front_R = Ship_Front_R.GetComponent<Ship_destroy>();
        script_front_L = Ship_Front_L.GetComponent<Ship_destroy>();
        Missile_shot_state = true;
        scene_script = scene_manager.GetComponent<scene_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene_script.GameMainSwitch() == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Missile_shot_state = false;

                if (hit.collider.tag == "target_1")
                {
                    if (script_front_L.Alive_or_dead() == true)
                    {
                        missile_start_number = 0;
                    }
                }
                else if (hit.collider.tag == "target_2")
                {
                    if (script_front_R.Alive_or_dead() == true)
                    {
                        missile_start_number = 1;
                    }
                }
                else if (hit.collider.tag == "target_3")
                {
                    if (script_back_L.Alive_or_dead() == true)
                    {
                        missile_start_number = 2;
                    }
                }
                else if (hit.collider.tag == "target_4")
                {
                    if (script_back_R.Alive_or_dead() == true)
                    {
                        missile_start_number = 3;
                    }
                }
            }
            else
            {
                Missile_shot_state = true;
            }


            Missile_Start_pos();
        }
    }

    /// <summary>
    /// ミサイルの生成　前左
    /// </summary>
    private void Missile_Generater_front_L()
    {
        if (Input.GetMouseButtonDown(0) && 
            text_script.bullet_count_front_L > 0 && 
            Missile_shot_state == true && 
            script_front_L.Alive_or_dead() == true)
        {
            missile_copy = Instantiate(missile, missile_start_pos, Quaternion.identity);               // ミサイルの複製
            script = missile_copy.GetComponent<missile_controller>();                                  // ミサイルのプレハブについているスクリプトの取得
            script.position = Input.mousePosition;                                                     // マウス位置座標を格納する
            text_script.bullet_front_L_out();                                                          // 残弾を１減らす
        }
    }

    /// <summary>
    /// ミサイルの生成　前右
    /// </summary>
    private void Missile_Generater_front_R()
    {
        if (Input.GetMouseButtonDown(0) &&
            text_script.bullet_count_front_R > 0 &&
            Missile_shot_state == true &&
            script_front_R.Alive_or_dead() == true)
        {
            missile_copy = Instantiate(missile, missile_start_pos, Quaternion.identity);               // ミサイルの複製
            script = missile_copy.GetComponent<missile_controller>();                                  // ミサイルのプレハブについているスクリプトの取得
            script.position = Input.mousePosition;                                                     // マウス位置座標を格納する
            text_script.bullet_front_R_out();                                                          // 残弾を１減らす
        }
    }

    /// <summary>
    /// ミサイルの生成　後左
    /// </summary>
    private void Missile_Generater_back_L()
    {
        if (Input.GetMouseButtonDown(0) &&
            text_script.bullet_count_back_L > 0 &&
            Missile_shot_state == true &&
            script_back_L.Alive_or_dead() == true)
        {
            missile_copy = Instantiate(missile, missile_start_pos, Quaternion.identity);               // ミサイルの複製
            script = missile_copy.GetComponent<missile_controller>();                                  // ミサイルのプレハブについているスクリプトの取得
            script.position = Input.mousePosition;                                                     // マウス位置座標を格納する
            text_script.bullet_back_L_out();                                                           // 残弾を１減らす
        }
    }

    /// <summary>
    /// ミサイルの生成　後右
    /// </summary>
    private void Missile_Generater_back_R()
    {
        if (Input.GetMouseButtonDown(0) &&
            text_script.bullet_count_back_R > 0 &&
            Missile_shot_state == true &&
            script_back_L.Alive_or_dead() == true)
        {
            missile_copy = Instantiate(missile, missile_start_pos, Quaternion.identity);               // ミサイルの複製
            script = missile_copy.GetComponent<missile_controller>();                                  // ミサイルのプレハブについているスクリプトの取得
            script.position = Input.mousePosition;                                                     // マウス位置座標を格納する
            text_script.bullet_back_R_out();                                                           // 残弾を１減らす
        }
    }

    /// <summary>
    /// ミサイルがどこから発射されるか
    /// </summary>
    private void Missile_Start_pos()
    {
        switch (missile_start_number)
        {
            case 0:
                missile_start_pos = Ship_Front_L.transform.position;
                Missile_Generater_front_L();
                break;
            case 1:
                missile_start_pos = Ship_Front_R.transform.position;
                Missile_Generater_front_R();    
                break;
            case 2:
                missile_start_pos = Ship_Back_L.transform.position;
                Missile_Generater_back_L();
                break;
            case 3:
                missile_start_pos = Ship_Back_R.transform.position;
                Missile_Generater_back_R();
                break;
        }
    }
    /// <summary>
    /// ミサイルの発射位置が前か後ろか決める変数を返す関数
    /// </summary>
    /// <param name="number">整数型の数字</param>
    /// <returns></returns>
    public int Missile_Start_Number(int number) { missile_start_number = number; return missile_start_number; }


    /// <summary>
    /// ミサイルの発射位置を前か後ろか判断する関数
    /// </summary>
    /// <returns>ミサイルの位置を前か後ろか返す</returns>
    public int missile_Start_number_state() { return missile_start_number; }
}
