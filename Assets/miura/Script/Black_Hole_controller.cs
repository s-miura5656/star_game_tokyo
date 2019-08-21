using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Hole_controller : MonoBehaviour
{
    public Vector3 centerPosition;      // 軌道の中心の座標
    float gravityConst_max = 80.0f;    // 定数(=GMm)のパラメータ
    float gravityConst_min = 50.0f;    // 定数(=GMm)のパラメータ
    float scale;                        // ブラックホールの拡大値
    public bool scale_switch;           // 拡大の拡大縮小切り替え

    List<GameObject> enemy_list;

    GameObject object_manager;
    Black_hole_missile_manager Black_Hole_Missile_s;

    private float size = 5f; // ブラックホールの最大サイズ

    // Start is called before the first frame update
    void Start()
    {
        enemy_list = GameObject.Find("Object_Manager").GetComponent<Enemy_manager>().enemy_list;
        scale = 0.0f;
        object_manager = GameObject.Find("Object_Manager");
        Black_Hole_Missile_s = object_manager.GetComponent<Black_hole_missile_manager>();
        scale_switch = true;
    }

    // Update is called once per frame
    void Update()
    {
        centerPosition = this.transform.position;

        //Attraction();
        Black_hole_size();
    }

    void Attraction() // 引力の関数
    {
        foreach (GameObject planet in enemy_list)
        {
            float attraction_distance = Vector3.Distance(centerPosition, planet.transform.position);

            //Debug.Log(attraction_distance);

            if (attraction_distance <= 2)
            {
                Vector3 distance = centerPosition - planet.transform.position;                        // 2物体間の距離(座標)
                Vector3 forceObject = gravityConst_max * distance / Mathf.Pow(distance.magnitude, 3); // 移動する物体にかかる力
                planet.GetComponent<Rigidbody>().AddForce(forceObject, ForceMode.Force);              // 物体にかける力
            }

            if (attraction_distance > 2 && attraction_distance <= 8)
            {
                Vector3 distance = centerPosition - planet.transform.position;                          // 2物体間の距離(座標)
                Vector3 forceObject = (gravityConst_min) * distance / Mathf.Pow(distance.magnitude, 3); // 移動する物体にかかる力
                planet.GetComponent<Rigidbody>().AddForce(forceObject, ForceMode.Force);                // 物体にかける力
            } 
        }
    }

    public void Black_hole_size() // ミサイルの爆発
    {
        if (scale_switch == true)
        {
            scale += 0.1f;
            transform.localScale = new Vector3(scale, scale, scale);

            if (scale >= size)
            {
                scale_switch = false;
            }
        }
        else if (scale_switch == false)
        {
            scale -= 0.1f;
            transform.localScale = new Vector3(scale, scale, scale);

            if (scale <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
