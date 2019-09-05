using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_count_manager : MonoBehaviour
{
    [System.NonSerialized]
    public int enemy_count;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy_count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// UFOから発射される爆弾をカウントしている関数
    /// </summary>
    /// <returns></returns>
    public int Enemy_count() { enemy_count ++; return enemy_count; }
}
