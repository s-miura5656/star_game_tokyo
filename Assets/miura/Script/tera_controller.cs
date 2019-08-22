using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tera_controller : MonoBehaviour
{
    float gravityConst_max = 0.0f;    // 定数(=GMm)のパラメータ
    float time = 0.02f;               // 何秒間で回るか
    GameObject Enemy;                 // 敵のオブジェクトを取得
    List<GameObject> enemy_list;      // 敵のリスト
    GameObject text_manager;          // HP用のテキストマネージャー取得
    Text_Manager text_script;         // テキストマネージャーのスクリプト取得

    // Start is called before the first frame update
    void Start()
    {
        enemy_list = GameObject.Find("Object_Manager").GetComponent<Enemy_manager>().enemy_list;
        text_manager = GameObject.Find("Text_Manager");
        text_script = text_manager.GetComponent<Text_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        Attraction();
        Earth_rotation();
    }

    void Attraction() // 引力の関数
    {
        foreach (GameObject enemy_copy in enemy_list)
        {
            //float attraction_distance = Vector3.Distance(transform.position, enemy_copy.transform.position);

            Vector3 distance = transform.position - enemy_copy.transform.position;                   // 2物体間の距離(座標)
            Vector3 forceObject = gravityConst_max * distance / Mathf.Pow(distance.magnitude, 3);    // 移動する物体にかかる力
            enemy_copy.GetComponent<Rigidbody>().AddForce(forceObject, ForceMode.Force);             // 物体にかける力
            
        }
    }

    private void OnTriggerEnter(Collider other) // 衝突判定
    {
        if (other.gameObject.tag == "enemy")
        {
            text_script.tera_hp -= 1;
        }
    }

    private void Earth_rotation()
    {
        transform.Rotate(new Vector3(0, 90f, 0) * (Time.deltaTime * time), Space.World);
    } 
    
}
