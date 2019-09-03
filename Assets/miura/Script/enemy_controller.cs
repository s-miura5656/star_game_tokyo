using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    // 出現のパターン
    private int START_PATTERN;

    // リスト
    List<GameObject> enemy_list;

    // エネルギーゲージ
    private GameObject Text_manager;
    private Text_Manager text_script;

    // 敵の初期配置を記録
    private Vector3 base_pos;

    // 敵の移動の終点
    private Vector3 end_pos;

    // 経過した時間の変数
    private float elapsed_time;

    // 等速で進むための時間の変数
    private float time;

    // 二点間の間を進む割合の変数
    private float ratio;

    // ルートのパターンを決める変数
    private int route_pattern;

    // スピード
    private int speed;



    // Start is called before the first frame update
    void Start()
    {
        Text_manager = GameObject.Find("Text_Manager");
        text_script = Text_manager.GetComponent<Text_Manager>();
        enemy_list = GameObject.Find("Object_Manager").GetComponent<Enemy_manager>().enemy_list;
        Enemy_route();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Move();
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
    /// 敵の消滅処理
    /// </summary>
    void Destroy_Enemy()
    {
        Destroy(gameObject);
        enemy_list.Remove(gameObject);
    }

    /// <summary>
    /// 敵の移動
    /// </summary>
    private void Enemy_Move()
    {
        elapsed_time += Time.deltaTime;

        float distance = Vector3.Distance(base_pos, end_pos);

        //Debug.Log(distance);

        time = distance / speed;

        // 指定された時間に対して経過した時間の割合
        if (ratio <= 1)
        {
            ratio = elapsed_time / time;
        }

        // 始点から終点までの移動処理
        transform.position = Vector3.Lerp(base_pos, end_pos, ratio);
    }

    /// <summary>
    /// 敵の移動ルートを決める始点と終点
    /// </summary>
    private void Enemy_route()
    {
        base_pos = transform.position;

        switch (route_pattern)
        {
            case 0:
                end_pos = new Vector3(6f, -12f, 0f);
                break;
            case 1:
                end_pos = new Vector3(5f, -12f, 0f);
                break;
            case 2:
                end_pos = new Vector3(4f, -12f, 0f);
                break;
            case 3:
                end_pos = new Vector3(3f, -12f, 0f);
                break;
            case 4:
                end_pos = new Vector3(2f, -12f, 0f);
                break;
            case 5:
                end_pos = new Vector3(1f, -12f, 0f);
                break;
            case 6:
                end_pos = new Vector3(0f, -12f, 0f);
                break;
            case 7:
                end_pos = new Vector3(-1f, -12f, 0f);
                break;
            case 8:
                end_pos = new Vector3(-2f, -12f, 0f);
                break;
            case 9:
                end_pos = new Vector3(-3f, -12f, 0f);
                break;
            case 10:
                end_pos = new Vector3(-4f, -12f, 0f);
                break;
            case 11:
                end_pos = new Vector3(-5f, -12f, 0f);
                break;
            case 12:
                end_pos = new Vector3(-6f, -12f, 0f);
                break;
        }
    }

    /// <summary>
    /// ルート決めるパターンの数字を返す
    /// </summary>
    /// <param name="number">パターン番号</param>
    /// <returns></returns>
    public int Route_pattern(int number) { route_pattern = number; return route_pattern; }

    /// <summary>
    /// 敵の移動速度
    /// </summary>
    /// <param name="number">速度の数値</param>
    /// <returns></returns>
    public int Enemy_Speed(int number) { speed = number; return speed; }
}

    
