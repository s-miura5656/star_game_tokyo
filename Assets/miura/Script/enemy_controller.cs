using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_controller : MonoBehaviour
{
    // 敵のHP
    [System.NonSerialized]
    public int HP;

    // 敵の速さ
    [System.NonSerialized]
    public Vector3 SPEED;

    // 敵の硬さ
    [System.NonSerialized]
    public int HARDNESS;
    [System.NonSerialized]
    public int METAL = 3;

    // 敵のサイズ
    [System.NonSerialized]
    public int SIZE;

    // 出現のパターン
    [System.NonSerialized]
    public int PATTERN;

    // 敵のオブジェクト
    [System.NonSerialized]
    public GameObject enemy;

    // 敵のサイズ 種類
    [System.NonSerialized]
    public float size_S = 0.4f;
    [System.NonSerialized]
    public float size_M = 0.6f;
    [System.NonSerialized]
    public float size_L = 0.8f;

    // 敵の速度 種類
    [System.NonSerialized]
    public Vector3 speed_S = new Vector3(0f, -0.5f, 0f);
    [System.NonSerialized]
    public Vector3 speed_M = new Vector3(0f, -0.3f, 0f);
    [System.NonSerialized]
    public Vector3 speed_L = new Vector3(0f, -0.1f, 0f);

    // 敵の発生場所_X 種類
    [System.NonSerialized]
    public float pos_X_left = -5f;
    //[System.NonSerialized]
    //public float pos_X_center = 0f;
    [System.NonSerialized]
    public float pos_X_right = 5f;
    [System.NonSerialized]
    public float pos_X_Random;

    // 敵の発生場所_Y 種類
    //[System.NonSerialized]
    //public float pos_Y_left = 13f;
    [System.NonSerialized]
    public float pos_Y_center = 14f;
    //[System.NonSerialized]
    //public float pos_Y_right = 13f;
    [System.NonSerialized]
    public float pos_Y_Random;

    // 敵の発生場所_Z
    [System.NonSerialized]
    public float pos_Z_ZERO = 0f;

    // 敵の硬さ 種類
    [System.NonSerialized]
    public int hardness_Small = 1;
    [System.NonSerialized]
    public int hardness_Middle = 3;
    [System.NonSerialized]
    public int hardness_Large = 10;
    [System.NonSerialized]
    public int hardness_Metal = 100;

    // 地球の位置
    [System.NonSerialized]
    public Vector3 earth = new Vector3(0.0f, -12.0f, 0.0f);

    // 等速で進めるための変数
    private float sumTime;
    // 何秒で到達するかの変数
    private float time = 5.0f;
    // 進む割合
    private float ratio;

    // リジッドボディの取得
    [System.NonSerialized]
    public new Rigidbody rigidbody;

    // リスト
    List<GameObject> enemy_list;

    // エネルギーゲージ
    GameObject Text_manager;
    Text_Manager text_script;

    // Start is called before the first frame update
    void Start()
    {
        Text_manager = GameObject.Find("Text_Manager");
        text_script = Text_manager.GetComponent<Text_Manager>();
        enemy_list = GameObject.Find("Object_Manager").GetComponent<Enemy_manager>().enemy_list;
        rigidbody = GetComponent<Rigidbody>();
        pos_X_Random = Random.Range(-5f, 5f);
        pos_Y_Random = Random.Range(13f, 14f);
        Enemy_Size();
        Enemy_Pattern();
        Enemy_Hardness();
        Enemy_move();
    }

    // Update is called once per frame
    void Update()
    {
        Screen_Out();
    }

    public void Enemy_move() //敵の移動
    {
        //rigidbody.AddForce(new Vector3(0f, 1f, 0f), ForceMode.Impulse);
        switch (PATTERN)
        {
            case 0:
                rigidbody.AddForce(speed_S, ForceMode.Impulse);
                break;
            case 1:
                rigidbody.AddForce(speed_M, ForceMode.Impulse);
                break;
            case 2:
                rigidbody.AddForce(speed_L, ForceMode.Impulse);
                break;
        }
    }

    void Destroy_Enemy() // 敵の消滅処理
    {
        Destroy(gameObject);
        enemy_list.Remove(gameObject);
    }

    private void OnTriggerEnter(Collider other) // 衝突判定
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy_Enemy();
            text_script.energy_count += 1;
        }

        if (other.gameObject.tag == "Bar")
        {
            Destroy_Enemy();
        }
    }

    void Screen_Out() // スクリーンアウトしたら消える
    {
        if (transform.position.x > 10.0f || transform.position.x < -10.0f ||
            transform.position.y > 15.0f || transform.position.y < -15.0f ||
            transform.position.z > 1.0f  || transform.position.z < -1.0f)
        {
            Destroy_Enemy();
        }

        if (transform.position.y < 0f && transform.position.x > 7.5f ||
            transform.position.y < 0f && transform.position.x < -7.5f)
        {
            Destroy_Enemy();
        }
    }

    public void Enemy_Pattern() //敵の発生位置
    {
        switch (PATTERN)
        {
            case 0:
                transform.position = new Vector3(pos_X_left, pos_Y_Random, pos_Z_ZERO);
                break;
            case 1:
                transform.position = new Vector3(pos_X_Random, pos_Y_center, pos_Z_ZERO);
                break;
            case 2:
                transform.position = new Vector3(pos_X_right, pos_Y_Random, pos_Z_ZERO);
                break;
        }
    }

    public void Enemy_Hardness() //敵のHP
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

    public void Enemy_Size() //敵の大きさ
    {
        switch (SIZE)
        {
            case 0:
                transform.localScale = new Vector3(size_S, size_S, size_S);
                SPEED = speed_S;
                break;
            case 1:
                transform.localScale = new Vector3(size_M, size_M, size_M);
                SPEED = speed_M;
                break;
            case 2:
                transform.localScale = new Vector3(size_L, size_L, size_L);
                SPEED = speed_L;
                break;
        }
    }
}

