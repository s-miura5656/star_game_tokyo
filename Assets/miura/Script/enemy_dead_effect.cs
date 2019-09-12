using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead_effect : MonoBehaviour
{
    // スケールサイズ
    private float scale = 4;
    // 小さくなる速度
    private float scale_speed;
    // 爆風の待機カウント
    private float time_count;

    // Start is called before the first frame update
    void Start()
    {
        scale_speed = 0.1f;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        scale_down(); 
    }
    /// <summary>
    /// 爆発の縮小
    /// </summary>
    private void scale_down()
    {
        time_count += Time.deltaTime;

        if (time_count >= 0.2f)
        {
            scale -= scale_speed;

            transform.localScale = new Vector3(scale, scale, scale);
        }

        if (scale <= 0)
        {
            time_count = 0f;
            Destroy(gameObject);
        }
    }
}
