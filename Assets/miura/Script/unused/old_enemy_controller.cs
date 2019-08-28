using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class old_enemy_controller : MonoBehaviour
{
    // 敵のHP
    private int HP;

    // 敵の速さ
    private Vector3 SPEED;

    // 敵の硬さ
    private int HARDNESS;
    private int METAL = 3;

    // 敵のサイズ
    [System.NonSerialized]
    public int SIZE_PATTERN;

    // 出現のパターン
    private int START_PATTERN;

    // 敵のサイズ 種類
    private float size_S = 0.4f;
    private float size_M = 0.6f;
    private float size_L = 1.2f;

    // 敵の速度 種類
    private Vector3 speed_S;
    private Vector3 speed_M;
    private Vector3 speed_L;
    private Vector3 speed_Division = new Vector3(0f, -0.3f, 0f);

    // 敵の発生場所_X 種類
    private float pos_X_Random;
    private float pos_X_Right = 10f;
    private float pos_X_Left = -10f;

    // 敵の発生場所_Y 種類
    private float pos_Y_Random;
    private float pos_Y_Center = 13f;

    // 敵の発生場所_Z
    private float pos_Z_ZERO = 0f;

    // 敵のHP 種類
    private int hardness_Small = 1;
    private int hardness_Middle = 3;
    private int hardness_Large = 10;
    private int hardness_Metal = 100;
    // リジッドボディの取得
    [System.NonSerialized]
    public new Rigidbody rigidbody;

    // リスト
    List<GameObject> enemy_list;

    // エネミーマネージャーのスクリプト
    Enemy_manager enemy_Manager_script;

    // エネルギーゲージ
    private GameObject Text_manager;
    private Text_Manager text_script;

    // 分裂後のオブジェクト
    private GameObject stone_2;
    private GameObject stone_2_copy;

    // ランダム
    private int RANDOM_size; // サイズ

    // 分裂するときのステート
    private bool division_state;

    // 分裂時に使う時間
    private float division_time;

    // 分裂するタイミング
    private int division_timing = 8;

    // 生成か分裂かのステート
    [System.NonSerialized]
    public bool make_division_state;

    // Start is called before the first frame update
    void Start()
    {
        Text_manager = GameObject.Find("Text_Manager");
        text_script = Text_manager.GetComponent<Text_Manager>();
        enemy_list = GameObject.Find("Object_Manager").GetComponent<Enemy_manager>().enemy_list;
        enemy_Manager_script = GameObject.Find("Object_Manager").GetComponent<Enemy_manager>();
        rigidbody = GetComponent<Rigidbody>();

        if (make_division_state == false)
        {
            Random_number();
            Enemy_Pattern_First();
            Enemy_move_size();
        }
        else
        {
            SIZE_PATTERN = 3;
            Enemy_move_size();
        }


    }

    // Update is called once per frame
    void Update()
    {
        Screen_Out();

        if (SIZE_PATTERN == 2)
        {
            Division_timing();
        }
    }

    /// <summary>
    /// 敵の消滅処理
    /// </summary>
    void Destroy_Enemy()
    {
        Destroy(gameObject);
        enemy_list.Remove(gameObject);
    }

    /// <summary>
    /// 爆風と地球に対しての当たり判定
    /// </summary>
    /// <param name="other"> 爆風、地球</param>
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") // 爆風に当たったらエネルギーを１手に入れて消える
        {
            Destroy_Enemy();
            text_script.energy_count += 1;
        }

        if (other.gameObject.tag == "Earth") // 地球に当たったら消える
        {
            Destroy_Enemy();
        }
    }

    /// <summary>
    /// 敵の移動とサイズ
    /// </summary>
    public void Enemy_move_size()
    {
        switch (SIZE_PATTERN)
        {
            case 0: // 分裂前のSサイズ
                transform.localScale = new Vector3(size_S, size_S, size_S);
                rigidbody.AddForce(speed_S, ForceMode.Impulse);
                break;
            case 1: // 分裂前のMサイズ
                transform.localScale = new Vector3(size_M, size_M, size_M);
                rigidbody.AddForce(speed_M, ForceMode.Impulse);
                break;
            case 2: // 分裂前のLサイズ
                transform.localScale = new Vector3(size_L, size_L, size_L);
                rigidbody.AddForce(speed_L, ForceMode.Impulse);
                enemy_Manager_script.L_max_count ++;
                break;
            case 3: // 分裂した時のサイズ
                transform.localScale = new Vector3(size_S, size_S, size_S);
                rigidbody.AddForce(speed_Division, ForceMode.Impulse);
                break;
        }
    }

    /// <summary>
    /// ランダムな変数の処理(分裂前)
    /// </summary>
    void Random_number()
    {
        if (enemy_Manager_script.L_max_count < 2)
        {
            SIZE_PATTERN = Random.Range(0, 3);
        }
        else
        {
            SIZE_PATTERN = Random.Range(0, 2);
        }

        pos_X_Random = Random.Range(-10f, 10f);
        pos_Y_Random = Random.Range(10f, 13f);
        START_PATTERN = Random.Range(0, 3);
    }

    /// <summary>
    /// 敵の発生位置
    /// </summary>
    public void Enemy_Pattern_First()
    {
        switch (START_PATTERN)
        {
            case 0:
                transform.position = new Vector3(pos_X_Right, pos_Y_Random, pos_Z_ZERO);
                speed_S = new Vector3(Random.Range(-0.4f, -0.6f), -1f, 0f);
                speed_M = new Vector3(Random.Range(-0.3f, -0.5f), -0.7f, 0f);
                speed_L = new Vector3(Random.Range(-0.2f, -0.4f), -0.5f, 0f);
                break;

            case 1:
                transform.position = new Vector3(pos_X_Random, pos_Y_Center, pos_Z_ZERO);

                if (pos_X_Random < 0f)
                {
                    speed_S = new Vector3(Random.Range(0.1f, 0.3f), -1f, 0f);
                    speed_M = new Vector3(Random.Range(0.1f, 0.3f), -0.8f, 0f);
                    speed_L = new Vector3(Random.Range(0.1f, 0.3f), -0.5f, 0f);
                }
                else if (pos_X_Random > 0f)
                {
                    speed_S = new Vector3(Random.Range(-0.1f, -0.3f), -1f, 0f);
                    speed_M = new Vector3(Random.Range(-0.1f, -0.3f), -0.8f, 0f);
                    speed_L = new Vector3(Random.Range(-0.1f, -0.3f), -0.5f, 0f);
                }
                break;

            case 2:
                transform.position = new Vector3(pos_X_Left, pos_Y_Random, pos_Z_ZERO);
                speed_S = new Vector3(Random.Range(0.4f, 0.6f), -1f, 0f);
                speed_M = new Vector3(Random.Range(0.3f, 0.5f), -0.7f, 0f);
                speed_L = new Vector3(Random.Range(0.2f, 0.4f), -0.5f, 0f);
                break;
        }
    }

    /// <summary>
    /// 敵のHP
    /// </summary>
    public void Enemy_Hardness()
    {
        switch (HARDNESS)
        {
            case 0:
                HP = hardness_Small;
                break;
            case 1:
                HP = hardness_Middle;
                break;
            case 2:
                HP = hardness_Large;
                break;
            case 3:
                HP = hardness_Metal;
                break;
        }
    }


    /// <summary>
    /// スクリーンアウトしたら消える
    /// </summary>
    void Screen_Out() 
    {
        if (transform.position.x > 20.0f || transform.position.x < -20.0f ||
            transform.position.y > 20.0f || transform.position.y < -20.0f ||
            transform.position.z > 2.0f  || transform.position.z < -2.0f)
        {
            Destroy_Enemy();
        }
    }

    /// <summary>
    /// 分裂するタイミング
    /// </summary>
    void Division_timing()
    {
        division_time += Time.deltaTime;

        if (division_time >= division_timing)
        {
            if (division_state == false)
            {
                enemy_Manager_script.Enemy_division(transform.position + new Vector3(0.2f, 0f, 0f));
                enemy_Manager_script.Enemy_division(transform.position + new Vector3(0f, -0.2f, 0f));
                enemy_Manager_script.Enemy_division(transform.position + new Vector3(-0.2f, 0f, 0f));
                division_state = true;
            }
            
            division_time = 0f;
        }

        if (division_state == true)
        {
            Destroy_Enemy();
        }
    }
}

