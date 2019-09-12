using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Hole_controller : MonoBehaviour
{
    public Vector3 centerPosition;      // 軌道の中心の座標
    //float gravityConst_max = 80.0f;   // 定数(=GMm)のパラメータ
    //float gravityConst_min = 50.0f;   // 定数(=GMm)のパラメータ
    float scale;                        // ブラックホールの拡大値
    [System.NonSerialized]
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

    // Z軸の固定
    private float fixed_z_axis = 0f;

    // ミサイルの爆発音
    [SerializeField]
    private AudioClip explosion_sound_large;
    [SerializeField]
    private AudioClip explosion_sound_small;
    // オーディオソースの取得
    private AudioSource audiosource;
    // 爆発の大か小の判断
    private bool explosion_state;
    // Start is called before the first frame update
    void Start()
    {
        scale = 0.0f;
        object_manager = GameObject.Find("Object_Manager");
        Black_Hole_Missile_s = object_manager.GetComponent<Black_hole_missile_manager>();
        scale_switch = true;
        audiosource = gameObject.GetComponent<AudioSource>();

        if (explosion_state == true)
        {
            size = 1f;
            scale_speed_first = 100f;
            scale_speed_end = 5;
            waiting_time_number = 0.5f;
            audiosource.PlayOneShot(explosion_sound_small);
        }
        else
        {
            size = 4f;
            scale_speed_first = 100f;
            scale_speed_end = 2;
            waiting_time_number = 1.5f;
            audiosource.PlayOneShot(explosion_sound_large);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //centerPosition = transform.position;
        //Attraction();
        transform.position = new Vector3(transform.position.x, transform.position.y, fixed_z_axis); 
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

    public void ExplosionState(bool switch_)
    {
        explosion_state = switch_;
    }
}
