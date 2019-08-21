using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_manager : MonoBehaviour
{
    public List<GameObject> enemy_list = new List<GameObject>();

    enum  Enemy_Type
    {
        STONE,
        METAL,
    }

    // 敵を出す間隔
    [System.NonSerialized]
    private float generator_time = 0.8f;
    // 時間
    [System.NonSerialized]
    private float time_ = 0f;

    // 敵の種類
    private Enemy_Type type;
    // ランダムに敵の種類を出すための変数
    private int random;
    // ランダムの最小値
    private int Type_min = 0;
    // ランダムの最大値
    private int Type_max = 2;
    // 敵のタイプ
    private int stone = 0;
    // リセット用変数
    private int Zero = 0;
    // コピーしたオブジェクトの取得
    private GameObject enemy_copy;
    // エネミーパラメーター付きのオブジェクトを取得
    private GameObject enemy_p_obj_S;
    private GameObject enemy_p_obj_M;
    // エネミーパラメーターのスクリプトを取得
    private enemy_controller script;
    // ランダム
    private int RANDOM_size;
    private int RANDOM_pattern;
    private float RANDOM_move_L;
    private float RANDOM_move_R;


    private void Start()
    {
        enemy_p_obj_S = (GameObject)Resources.Load("Stone");

        enemy_p_obj_M = (GameObject)Resources.Load("Metal");
    }

    private void Update()
    {
        
        time_ += Time.deltaTime;

        if (time_ >= generator_time)
        {
            random = Random.Range(Type_min, Type_max);

            if (random == stone)
            {
                type = Enemy_Type.STONE;
                Enemy_Generator(type);
            }
            else
            {
                type = Enemy_Type.METAL;
                Enemy_Generator(type);
            }

            time_ = Zero;
        }
    }

    void Enemy_Generator(Enemy_Type type)
    {
        switch (type)
        {
            case Enemy_Type.STONE:
                enemy_copy = Instantiate(enemy_p_obj_S, new Vector3(0f, 12f, 0f), transform.rotation);
                script = enemy_copy.GetComponent<enemy_controller>();

                RANDOM_size = Random.Range(0, 3);
                RANDOM_pattern = Random.Range(0, 3);
                script.HARDNESS = script.SIZE;     // 硬さ、HP
                script.SIZE = RANDOM_size;         // 大きさ、速度
                script.PATTERN = RANDOM_pattern;   // 出現位置
                script.rigidbody = enemy_copy.GetComponent<Rigidbody>();
                enemy_list.Add(enemy_copy);
                break;

            case Enemy_Type.METAL:
                enemy_copy = Instantiate(enemy_p_obj_M, new Vector3(0f, 12f, 0f), transform.rotation);
                script = enemy_copy.GetComponent<enemy_controller>();

                RANDOM_size = Random.Range(0, 3);
                RANDOM_pattern = Random.Range(0, 3);
                script.HARDNESS = script.METAL;    // 硬さ、HP
                script.SIZE = RANDOM_size;         // 大きさ、速度
                script.PATTERN = RANDOM_pattern;   // 出現位置
                script.rigidbody = enemy_copy.GetComponent<Rigidbody>();
                enemy_list.Add(enemy_copy);
                break;
        }
    }

}




