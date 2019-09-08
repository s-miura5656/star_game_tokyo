using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo_generator : MonoBehaviour
{
    [SerializeField]
    private GameObject ufo;            // UFOのオブジェクトを取得
    private GameObject ufo_copy;       // 複製用のオブジェクト変数
    private float time_count;          // 時間のカウント
    private float generator_time = 3f; // 生成間隔
    private int ufo_count;             // UFOのカウント
    private int ufo_max_count;         // UFOの生成する最大数
    
    // Start is called before the first frame update
    void Start()
    {
        ufo_max_count = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time_count += Time.deltaTime;
        
        if (time_count >= generator_time && ufo_count < ufo_max_count)
        {
            ufo_copy = Instantiate(ufo);
            ufo_count++;
            time_count = 0f;
        }
    }

    private void OnEnable()
    {
        ufo_count = 0;
    }
}
