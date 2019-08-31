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
    private int Type_max = 27;

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

    // 敵を出した数
    private int enemy_count;

    private void Start()
    {
        enemy_Stone = (GameObject)Resources.Load("Stone");

        generator_time = 1.5f;
    }

    private void Update()
    {
        time_ += Time.deltaTime;

        if (time_ >= generator_time && enemy_count < 20)
        {
            random = Random.Range(Type_min, Type_max);

            Enemy_Generator();

            enemy_count += 1;

            time_ = Zero;
        }
    }

    /// <summary>
    /// 敵の生成
    /// </summary>
    void Enemy_Generator()
    {
        enemy_copy = Instantiate(enemy_Stone, new Vector3(0f, 13f, 0f), transform.rotation);
        script = enemy_copy.GetComponent<enemy_controller>();
        script.Route_pattern(random);
        enemy_list.Add(enemy_copy);
    }
}




