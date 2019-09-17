using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_manager : MonoBehaviour
{
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

    // 生成するエネミーの最大数
    private int enemy_pop;

    // コピーしたオブジェクトの取得
    private GameObject enemy_copy;

    // エネミーパラメーター付きのオブジェクトを取得
    private GameObject enemy_bomb;
    
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
    private float speed;

    // 敵の攻撃のカウント
    private int enemy_count;

    // シーンマネージャースクリプトの取得
    private scene_manager scene_manager_script;

    // オーディオソースの取得
    private AudioSource audiosource;

    // 効果音の取得
    [SerializeField]
    private AudioClip lanchar_sound;

    private void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        scene_manager_script = GameObject.Find("Scene_manager").GetComponent<scene_manager>();
        enemy_bomb = (GameObject)Resources.Load("bomb");
        input_time = Random.Range(0.5f, 2f);
        enemy_count = 0;
        GeneratorBombTime(scene_manager_script.EnemyLevel());
        EnemyMaxPop(scene_manager_script.EnemyLevel());
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
        enemy_copy = Instantiate(enemy_bomb, transform.position, Quaternion.identity);
        script = enemy_copy.GetComponent<enemy_controller>();
        script.Route_pattern(end_position);
        speed = Random.Range(2, 4);
        script.Enemy_Speed(speed);
        audiosource.PlayOneShot(lanchar_sound);
    }

    /// <summary>
    /// 敵の軌道の始点と終点
    /// </summary>
    private void Enemy_first_pop()
    {
        end_pos = Random.Range(0, 4);
        Enemy_Generator(end_pos);
    }

    /// <summary>
    /// 敵の生成間隔と最大数の制限
    /// </summary>
    private void Pop_state_first()
    {
        time_ += Time.deltaTime;

        if (time_ >= generator_time && enemy_count < enemy_pop)
        { 
            Enemy_first_pop();

            enemy_count++;

            GeneratorBombTime(scene_manager_script.EnemyLevel());

            time_ = Zero;

        }
    }

    /// <summary>
    /// 敵がボムを落とす時間
    /// </summary>
    /// <param name="time">時間</param>
    private void GeneratorBombTime(int level)
    {
        switch (level)
        {
            case 1: generator_time = Random.Range(1.5f, 2.5f);   break;
            case 2: generator_time = Random.Range(1f, 2f); break;
            case 3: generator_time = Random.Range(0.5f, 1.5f); break;
        }
    }

    /// <summary>
    /// ウェーブごとにボムをいくつまで出すか決める
    /// </summary>
    private void EnemyMaxPop(int level)
    {
        switch (level)
        {
            case 1: enemy_pop = Random.Range(3, 4); break;
            case 2: enemy_pop = Random.Range(3, 5); break;
            case 3: enemy_pop = Random.Range(5, 7); break;
        }
    }
}






