﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
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
    private float speed;

    // シーンマネージャースクリプトの取得
    private scene_manager scene_manager_script;

    // 爆発のエフェクトのプレハブを入れる変数
    private GameObject effect;
    // 複製されるエフェクト
    private GameObject effect_copy;
    // テキストマネージャースクリプトの取得
    private Text_Manager text_script;
    // Start is called before the first frame update
    void Start()
    {
        scene_manager_script = GameObject.Find("Scene_manager").GetComponent<scene_manager>();
        text_script = GameObject.Find("Text_Manager").GetComponent<Text_Manager>();
        effect = (GameObject)Resources.Load("explosion_enemy");
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
        // 爆風に当たったら消える
        if (other.gameObject.tag == "Player") 
        {
            effect_copy = Instantiate(effect, transform.position, transform.rotation);
            scene_manager_script.EnamyAttack();
            text_script.ComboSwitchOn();
            text_script.ComboCountUp();
            Destroy_Enemy();
        }

        // 敵の爆風に当たったら消える
        if (other.gameObject.tag == "enemy_explosion")
        {
            effect_copy = Instantiate(effect, transform.position, transform.rotation);
            scene_manager_script.EnamyAttack();
            text_script.ComboSwitchOn();
            text_script.ComboCountUp();
            Destroy_Enemy();
        }

        // 戦艦に当たったら消える
        if (other.gameObject.tag == "target_1" ||
            other.gameObject.tag == "target_2" ||
            other.gameObject.tag == "target_3" ||
            other.gameObject.tag == "target_4")   
        {
            effect_copy = Instantiate(effect, transform.position, transform.rotation);
            scene_manager_script.EnamyAttack();
            Destroy_Enemy();
        }

        // 画面下に到達したらゲームオーバー
        if (other.gameObject.tag == "Bar")
        {
            Destroy_Enemy();
            scene_manager_script.SetGameScene(scene_manager.GameScene.GameOver);
        }
    }

    /// <summary>
    /// 敵の消滅処理
    /// </summary>
    void Destroy_Enemy()
    {
        Destroy(gameObject);
        //enemy_list.Remove(gameObject);
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
                end_pos = new Vector3(-6f, -11.5f, 0f);
                break;
            case 1:
                end_pos = new Vector3(6f, -11.5f, 0f);
                break;
            case 2:
                end_pos = new Vector3(-2f, -13f, 0f);
                break;
            case 3:
                end_pos = new Vector3(2f, -13f, 0f);
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
    public float Enemy_Speed(float number) { speed = number; return speed; }
}

    
