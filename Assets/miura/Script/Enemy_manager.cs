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
    private int Type_max = 2;

    // 敵のタイプ
    private int stone = 0;

    // リセット用変数
    private int Zero = 0;

    // コピーしたオブジェクトの取得
    private GameObject enemy_copy;

    // エネミーパラメーター付きのオブジェクトを取得
    private GameObject enemy_Stone;
    private GameObject enemy_Division;
    private GameObject enemy_Metal;

    // エネミーパラメーターのスクリプトを取得
    private old_enemy_controller script;

    // ランダム
    private int RANDOM_pattern;
    private float RANDOM_move_L;
    private float RANDOM_move_R;

    // 敵を出した数
    private int enemy_count;

    // Lの生成数を制限する変数
    [System.NonSerialized]
    public int L_max_count;


    private void Start()
    {
        enemy_Stone = (GameObject)Resources.Load("Stone");

        enemy_Division = (GameObject)Resources.Load("Stone_2");

        enemy_Metal = (GameObject)Resources.Load("Metal");

        generator_time = 1.5f;
    }

    private void Update()
    {
        time_ += Time.deltaTime;

        if (time_ >= generator_time && enemy_count <= 20)
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

            enemy_count += 1;

            time_ = Zero;
        }
    }

    /// <summary>
    /// 敵の生成
    /// </summary>
    /// <param name="type">敵の種類</param>
    void Enemy_Generator(Enemy_Type type)
    {
        switch (type)
        {
            case Enemy_Type.STONE:
                enemy_copy = Instantiate(enemy_Stone, new Vector3(0f, 13f, 0f), transform.rotation);
                script = enemy_copy.GetComponent<old_enemy_controller>();
                    
                enemy_list.Add(enemy_copy);
                break;

            case Enemy_Type.METAL:
                enemy_copy = Instantiate(enemy_Metal, new Vector3(0f, 13f, 0f), transform.rotation);
                enemy_list.Add(enemy_copy);
                break;
        } 
    }

    
    /// <summary>
    /// 分裂
    /// </summary>
    public void Enemy_division(Vector3 pop_pos)
    {
        enemy_copy = Instantiate(enemy_Division, pop_pos, transform.rotation);
        script = enemy_copy.GetComponent<old_enemy_controller>();
        enemy_list.Add(enemy_copy);
        script.make_division_state = true;
    }

    
}




