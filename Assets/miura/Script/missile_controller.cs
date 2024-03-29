﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_controller : MonoBehaviour
{
    // マウスの位置座標を格納する変数
    [System.NonSerialized]
    public Vector3 position;

    // マウスのスクリーン座標をワールド座標に変換した位置座標を格納する変数
    [System.NonSerialized]
    public Vector3 screenToWorldPointPosition;

    // 速度を格納する変数
    [System.NonSerialized]
    float speed = 0.01f;

    // Z軸修正の値
    [System.NonSerialized]
    float z_modification = 20.0f;
    // 等速で進めるための変数
    [System.NonSerialized]
    float sumTime;
    // 何秒で到達するかの変数
    [System.NonSerialized]
    float time = 5.0f;
    // 進む割合
    [System.NonSerialized]
    public float ratio;
    // ミサイルの発射位置
    [System.NonSerialized]
    public Vector3 base_missile_pos;
    [System.NonSerialized]
    // ミサイル一発の発射判定　true = 発射できる　false = 発射できない
    bool missile_pop;
    [System.NonSerialized]
    // 複製したブラックホール
    GameObject black_hole_copy;
    // prefabの取得のための変数
    [System.NonSerialized]
    GameObject black_hole;


    // Start is called before the first frame update
    void Start()
    {
        sumTime = 0.0f;
        missile_pop = true;
        base_missile_pos = new Vector3(0.0f, -12.0f, 0.0f);
        black_hole = (GameObject)Resources.Load("Black_Hole");
    }

    // Update is called once per frame
    void Update()
    {
        Missile_move();
        Missile_pop();
    }

    public void Missile_move()
    { 
        sumTime += Time.deltaTime;

        // Z軸の修正
        position.z = z_modification;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

        // 指定された時間に対して経過した時間の割合
        if (ratio <= 1)
        {
            ratio = sumTime / time;
        }

        // ワールド座標に変換されたマウス座標と追従させたいオブジェクトの距離を測り、それを割る速度したものを現在位置に加算していく
        this.transform.position = Vector3.Lerp(base_missile_pos, screenToWorldPointPosition, ratio);

       
    }

    public void Missile_pop() // 到達したらブラックホールが生成される
    {
        if (missile_pop == true)
        {
            if (this.transform.position == screenToWorldPointPosition)
            {
                // ブラックホールの生成
                black_hole_copy = Instantiate(black_hole, transform.position, Quaternion.identity);
                missile_pop = false;
                Destroy(gameObject);
            }
        }
    }


}
