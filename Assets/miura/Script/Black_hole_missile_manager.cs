using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_hole_missile_manager : MonoBehaviour
{
    [SerializeField]
    GameObject missile;              // プレハブのミサイルを入れるオブジェクト
    GameObject missile_copy;         // ミサイルの複製用オブジェクト
    missile_controller script;       // ミサイルコントローラーを入れるスクリプト
    [SerializeField]
    GameObject text_manager;         // テキストマネージャーの取得
    Text_Manager text_script;        // テキストマネージャーのスクリプトの取得
    public float relord_time = 0f; // 次弾撃てるまでの時間
    float time;                      // 時間
    bool missile_shot;               // ミサイルを発射してるかしてないか

    // Start is called before the first frame update
    void Start()
    {
        //missile = (GameObject)Resources.Load("Missile");
        //text_manager = GameObject.Find("Text_Manager");
        text_script = text_manager.GetComponent<Text_Manager>();
        missile_shot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Missile_Generater();
    }

    private void Missile_Generater()
    {

        if (missile_shot == true)
        {
            if (Input.GetMouseButtonDown(0) && text_script.bullet_count > 0)
            {
                missile_copy = Instantiate(missile, new Vector3(0.0f, -12.0f, 0.0f), Quaternion.identity); // ミサイルの複製
                script = missile_copy.GetComponent<missile_controller>();                                  // ミサイルのプレハブについているスクリプトの取得
                script.position = Input.mousePosition;                                                     // マウス位置座標を格納する
                text_script.bullet_count -= 1;                                                             // 残弾を１減らす
                //missile_shot = false;
            }
        }
        //else
        //{
        //    time += Time.deltaTime;

        //    if (time >= relord_time)
        //    {
        //        missile_shot = true;
        //        time = 0f;
        //    }
        //}

    }
}
