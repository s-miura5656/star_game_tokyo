using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dead_effect : MonoBehaviour
{
    private float scale = 1f;       // スケールサイズ
    private float scale_speed; // 小さくなる速度
    // Start is called before the first frame update
    void Start()
    {
        scale_speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        scale_down();
    }

    /// <summary>
    /// 爆発の縮小
    /// </summary>
    private void scale_down()
    {
        scale -= Time.deltaTime * scale_speed;

        transform.localScale = new Vector3(scale, scale, scale);

        if (scale <= 0)
        {
            Destroy(gameObject);
        }
    }
}
