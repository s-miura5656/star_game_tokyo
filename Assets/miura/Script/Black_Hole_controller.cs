using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Hole_controller : MonoBehaviour
{
    public Vector3 centerPosition;      // 軌道の中心の座標
    float gravityConst_max = 80.0f;     // 定数(=GMm)のパラメータ
    float gravityConst_min = 50.0f;     // 定数(=GMm)のパラメータ
    float scale;                        // ブラックホールの拡大値
    public bool scale_switch;           // 拡大の拡大縮小切り替え

    //List<GameObject> enemy_list;

    GameObject object_manager;
    Black_hole_missile_manager Black_Hole_Missile_s;
    [System.NonSerialized]
    public float size;                 // ブラックホールの最大サイズ
    [System.NonSerialized]
    public float scale_speed_first;    // 爆発の拡大速度
    [System.NonSerialized]
    public float scale_speed_end;      // 爆発の縮小速度
    [System.NonSerialized]
    public float waiting_time_number;  // 爆発の待機時間を決める変数
    private float waiting_time;        // 爆発の待機時間を図る

    // Start is called before the first frame update
    void Start()
    {
        //enemy_list = GameObject.Find("Object_Manager").GetComponent<Enemy_manager>().enemy_list;
        scale = 0.0f;
        object_manager = GameObject.Find("Object_Manager");
        Black_Hole_Missile_s = object_manager.GetComponent<Black_hole_missile_manager>();
        scale_switch = true;
    }

    // Update is called once per frame
    void Update()
    {
        centerPosition = transform.position;

        //Attraction();
        Black_hole_size();
        
    }

    //void Attraction() // 引力の関数
    //{
    //    foreach (GameObject planet in enemy_list)
    //    {
    //        float attraction_distance = Vector3.Distance(centerPosition, planet.transform.position);

    //        //Debug.Log(attraction_distance);

    //        if (attraction_distance <= 2)
    //        {
    //            Vector3 distance = centerPosition - planet.transform.position;                        // 2物体間の距離(座標)
    //            Vector3 forceObject = gravityConst_max * distance / Mathf.Pow(distance.magnitude, 3); // 移動する物体にかかる力
    //            planet.GetComponent<Rigidbody>().AddForce(forceObject, ForceMode.Force);              // 物体にかける力
    //        }

    //        if (attraction_distance > 2 && attraction_distance <= 8)
    //        {
    //            Vector3 distance = centerPosition - planet.transform.position;                          // 2物体間の距離(座標)
    //            Vector3 forceObject = (gravityConst_min) * distance / Mathf.Pow(distance.magnitude, 3); // 移動する物体にかかる力
    //            planet.GetComponent<Rigidbody>().AddForce(forceObject, ForceMode.Force);                // 物体にかける力
    //        } 
    //    }
    //}

    public void Black_hole_size() // ミサイルの爆発
    {
        if (scale_switch == true)
        {
            scale += Time.deltaTime * scale_speed_first;

            transform.localScale = new Vector3(scale, scale, scale);

            if (scale >= size)
            {
                scale_switch = false;
            }
        }
        else if (scale_switch == false)
        {
            waiting_time += 0.1f;

            if (waiting_time >= waiting_time_number)
            {
                scale -= Time.deltaTime * scale_speed_end;

                transform.localScale = new Vector3(scale, scale, scale);

                if (scale <= 0)
                {
                    Destroy(gameObject);
                }
            }  
        }
    }
}
