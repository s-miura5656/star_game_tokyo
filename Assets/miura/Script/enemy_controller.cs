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
    public float SPEED;

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

    // 移動パターン
    [System.NonSerialized]
    public float  move_L;
    [System.NonSerialized]
    public float  move_R;

    // 敵のサイズ 種類
    [System.NonSerialized]
    public float size_S = 0.1f;
    [System.NonSerialized]
    public float size_M = 0.3f;
    [System.NonSerialized]
    public float size_L = 0.5f;

    // 敵の速度 種類
    [System.NonSerialized]
    public float speed_S = -0.005f;
    [System.NonSerialized]
    public float speed_M = -0.002f;
    [System.NonSerialized]
    public float speed_L = -0.0005f;

    // 敵の発生場所_X 種類
    [System.NonSerialized]
    public float pos_X_left = -8f;
    //[System.NonSerialized]
    //public float pos_X_center = 0f;
    [System.NonSerialized]
    public float pos_X_right = 8f;
    [System.NonSerialized]
    public float pos_X_Random;

    // 敵の発生場所_Y 種類
    //[System.NonSerialized]
    //public float pos_Y_left = 13f;
    [System.NonSerialized]
    public float pos_Y_center = 12f;
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
    [System.NonSerialized]
    private float sumTime;
    // 何秒で到達するかの変数
    [System.NonSerialized]
    private float time = 5.0f;
    // 進む割合
    [System.NonSerialized]
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
        pos_X_Random = Random.Range(-8f, 8f);
        pos_Y_Random = Random.Range(11f, 12f);
        move_L = Random.Range(0.001f, 0.05f);
        move_R = Random.Range(-0.001f, -0.05f);
        Enemy_Size();
        Enemy_Pattern();
        Enemy_Hardness();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy_move();
        Screen_Out();
    }

    public void Enemy_move() //敵の移動
    {
        //rigidbody.AddForce(new Vector3(0f, 1f, 0f), ForceMode.Impulse);
        switch (PATTERN)
        {
            case 0:
                transform.position += new Vector3(move_L, SPEED, 0f);
                break;
            case 1:
                transform.position += new Vector3(0f, SPEED, 0f);
                break;
            case 2:
                transform.position += new Vector3(move_R, SPEED, 0f);
                break;
        }
    }

    void Destroy_and_Creation() // 敵の消滅処理
    {
        Destroy(gameObject);
        enemy_list.Remove(gameObject);
    }

    private void OnTriggerEnter(Collider other) // 衝突判定
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy_and_Creation();
            text_script.energy_count += 1;
        }
    }

    void Screen_Out() // スクリーンアウトしたら消える
    {
        if (transform.position.x > 10.0f || transform.position.x < -10.0f ||
            transform.position.y > 15.0f || transform.position.y < -15.0f ||
            transform.position.z > 1.0f  || transform.position.z < -1.0f)
        {
            Destroy_and_Creation();
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

