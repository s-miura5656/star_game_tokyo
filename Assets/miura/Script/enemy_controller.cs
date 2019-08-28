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
    // Start is called before the first frame update
    void Start()
    {
        Text_manager = GameObject.Find("Text_Manager");
        text_script = Text_manager.GetComponent<Text_Manager>();
        base_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Move(base_pos, end_pos);
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
    public void Enemy_Move(Vector3 base_pos, Vector3 end_pos)
    {
        elapsed_time += Time.deltaTime;

        float distance = Vector3.Distance(base_pos, end_pos);

        //Debug.Log(distance);

        time = distance / 15;

        // 指定された時間に対して経過した時間の割合
        if (ratio <= 1)
        {
            ratio = elapsed_time / time;
        }

        // 始点から終点までの移動処理
        transform.position = Vector3.Lerp(base_pos, end_pos, ratio);
    }
}
