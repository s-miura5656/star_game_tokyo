using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_hole_missile_manager : MonoBehaviour
{
    // プレハブのミサイルを入れるオブジェクト
    [SerializeField]
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
    private bool missile_start_number;
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

    // Start is called before the first frame update
    void Start()
    {
        missile = (GameObject)Resources.Load("Missile");
        script = missile.GetComponent<missile_controller>();
        text_script = text_manager.GetComponent<Text_Manager>();
        missile_shot = true;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, 100))
        {
            Missile_shot_state = false;
        }
        else
        {
            Missile_shot_state = true;
        }


        Missile_Start_pos();
    }

    /// <summary>
    /// ミサイルの生成
    /// </summary>
    private void Missile_Generater()
    {
        if (Input.GetMouseButtonDown(0) && text_script.bullet_count > 0 && Missile_shot_state == true)
        {
            missile_copy = Instantiate(missile, missile_start_pos, Quaternion.identity);               // ミサイルの複製
            script = missile_copy.GetComponent<missile_controller>();                                  // ミサイルのプレハブについているスクリプトの取得
            script.position = Input.mousePosition;                                                     // マウス位置座標を格納する
            text_script.bullet_count -= 1;                                                             // 残弾を１減らす
        }
    }

    /// <summary>
    /// ミサイルがどこから発射されるか
    /// </summary>
    private void Missile_Start_pos()
    {
        switch (missile_start_number)
        {
            case true:

                if (script.screenToWorldPointPosition.x > 0)
                {
                    missile_start_pos = new Vector3(-2f, -6f, 0f);
                }
                else
                {
                    missile_start_pos = new Vector3(2f, -6f, 0f);
                }
                break;

            case false:

                if (script.screenToWorldPointPosition.x >= 0)
                {
                    missile_start_pos = new Vector3(-5f, -9.5f, 0f);
                }
                else
                {
                    missile_start_pos = new Vector3(5f, -9.5f, 0f);
                }
                break;
        }

        Missile_Generater();

    }
    /// <summary>
    /// ミサイルの発射位置が前か後ろか決める変数を返す関数
    /// </summary>
    /// <param name="number">整数型の数字</param>
    /// <returns></returns>
    public bool Missile_Start_Number(bool number) { missile_start_number = number; return missile_start_number; }


    /// <summary>
    /// ミサイルの発射位置を前か後ろか判断する関数
    /// </summary>
    /// <returns>ミサイルの位置を前か後ろか返す</returns>
    public bool missile_Start_number_state() { return missile_start_number; }
}
