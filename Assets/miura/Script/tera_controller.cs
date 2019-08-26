using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tera_controller : MonoBehaviour
{
    // 定数(=GMm)のパラメータ
    private float gravityConst_max;
    
    // 何秒間で回るか
    private float time = 0.02f;               
    // 敵のリスト
    List<GameObject> enemy_list;

    // HP用のテキストマネージャー取得
    private GameObject text_manager;

    // テキストマネージャーのスクリプト取得
    private Text_Manager text_script;

    // 最初だけ引力を強くするための時間
    private float Attraction_time;
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

    /// <summary>
    /// 引力の関数
    /// </summary>
    void Attraction()
    {

        foreach (GameObject enemy_copy in enemy_list)
        {
            float attraction_distance = Vector3.Distance(transform.position, enemy_copy.transform.position); // 敵との距離

            Debug.Log(attraction_distance);

            if (attraction_distance >= 29f)
            {
                gravityConst_max = 50f;                                                                  // 引力の強さ
                Vector3 distance = transform.position - enemy_copy.transform.position;                   // 2物体間の距離(座標)
                Vector3 forceObject = gravityConst_max * distance / Mathf.Pow(distance.magnitude, 3);    // 移動する物体にかかる力
                enemy_copy.GetComponent<Rigidbody>().AddForce(forceObject, ForceMode.Force);             // 物体にかける力
            }
            else
            {
                gravityConst_max = 10f;                                                                  // 引力の強さ
                Vector3 distance = transform.position - enemy_copy.transform.position;                   // 2物体間の距離(座標)
                Vector3 forceObject = gravityConst_max * distance / Mathf.Pow(distance.magnitude, 3);    // 移動する物体にかかる力
                enemy_copy.GetComponent<Rigidbody>().AddForce(forceObject, ForceMode.Force);             // 物体にかける力
            }

        }
    }

    /// <summary>
    /// 敵と当たったらHPを１減らす
    /// </summary>
    /// <param name="other">敵</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            text_script.tera_hp -= 1;
        }
    }

    /// <summary>
    /// 地球の回転
    /// </summary>
    private void Earth_rotation()
    {
        transform.Rotate(new Vector3(0, 90f, 0) * (Time.deltaTime * time), Space.World);
    } 
    
}
