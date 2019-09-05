using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_manager : MonoBehaviour
{
    public List<GameObject> enemy_list = new List<GameObject>();

    enum Enemy_Type
    {
        STONE,
        METAL,
    }

    // 敵を出す間隔
    private float generator_time;

    // 時間
    private float time_ = 0f;

    // 敵の種類
    private Enemy_Type type;

    // ランダムに敵の種類を出すための変数
    private int random;

    // ランダムの最小値
    private int Type_min = 0;

    // ランダムの最大値
    private int Type_max = 13;

    // 敵のタイプ
    private int stone = 0;

    // リセット用変数
    private int Zero = 0;

    // コピーしたオブジェクトの取得
    private GameObject enemy_copy;

    // エネミーパラメーター付きのオブジェクトを取得
    private GameObject enemy_Stone;
    
    // エネミーパラメーターのスクリプトを取得
    private enemy_controller script;

    // ランダム
    private int RANDOM_pattern;
    private float RANDOM_move_L;
    private float RANDOM_move_R;

    // POP位置
    private Vector3 first_pop;

    // 敵の軌道の終点
    private int end_pos;

    // 敵の生成間隔の変数
    private float input_time;

    // 敵の移動速度の変数
    private int speed;

    // テキストマネージャーの取得
    private GameObject Text_manager;
    // テキストマネージャーのスクリプトを取得
    private enemy_count_manager enemy_count_script;
    private void Start()
    {
        enemy_Stone = (GameObject)Resources.Load("Stone");
        input_time = Random.Range(0.5f, 2f);
        enemy_count_script = GameObject.Find("Object_Manager").GetComponent<enemy_count_manager>();
    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "attack_area")
        {
            Pop_state_first();
        }
    }

    /// <summary>
    /// 敵の生成
    /// </summary>
    void Enemy_Generator(int end_position)
    {
        enemy_copy = Instantiate(enemy_Stone, transform.position, transform.rotation);
        script = enemy_copy.GetComponent<enemy_controller>();
        script.Route_pattern(end_position);
        speed = Random.Range(2, 5);
        script.Enemy_Speed(speed);
        //enemy_list.Add(enemy_copy);
    }

    /// <summary>
    /// 敵の軌道の始点と終点
    /// </summary>
    private void Enemy_first_pop()
    {
        //switch (first_number)
        //{
        //    case 0:
        //        first_pop = new Vector3(6f, 13f, 0f);
        //        break;
        //    case 1:
        //        first_pop = new Vector3(5f, 13f, 0f);
        //        break;
        //    case 2:
        //        first_pop = new Vector3(4f, 13f, 0f);
        //        break;
        //    case 3:
        //        first_pop = new Vector3(3f, 13f, 0f);
        //        break;
        //    case 4:
        //        first_pop = new Vector3(2f, 13f, 0f);
        //        break;
        //    case 5:
        //        first_pop = new Vector3(1f, 13f, 0f);
        //        break;
        //    case 6:
        //        first_pop = new Vector3(0f, 13f, 0f);
        //        break;
        //    case 7:
        //        first_pop = new Vector3(-1f, 13f, 0f);
        //        break;
        //    case 8:
        //        first_pop = new Vector3(-2f, 13f, 0f);
        //        break;
        //    case 9:
        //        first_pop = new Vector3(-3f, 13f, 0f);
        //        break;
        //    case 10:
        //        first_pop = new Vector3(-4f, 13f, 0f);
        //        break;
        //    case 11:
        //        first_pop = new Vector3(-5f, 13f, 0f);
        //        break;
        //    case 12:
        //        first_pop = new Vector3(-6f, 13f, 0f);
        //        break;
        //}

        end_pos = Random.Range(0, 4);
        Enemy_Generator(end_pos);
    }

    /// <summary>
    /// 敵の生成間隔と最大数の制限
    /// </summary>
    private void Pop_state_first()
    {
        time_ += Time.deltaTime;

        generator_time = input_time;

        if (time_ >= generator_time && enemy_count_script.enemy_count < 20)
        { 
            Enemy_first_pop();

            enemy_count_script.Enemy_count();

            input_time = Random.Range(0.5f, 2f);

            time_ = Zero;

        }
    }

    
}






