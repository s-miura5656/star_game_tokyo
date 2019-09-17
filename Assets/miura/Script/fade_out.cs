using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_out : MonoBehaviour
{
    // 時間のカウント
    private float time_count;
    // デストロイする時間
    private float destroy_time = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        time_count += Time.deltaTime;

        if (time_count >= destroy_time)
        {
            Destroy(gameObject);
        }
    }
}
