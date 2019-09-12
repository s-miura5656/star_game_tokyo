using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo_generator : MonoBehaviour
{
    // UFOのオブジェクトを取得
    [SerializeField]
    private GameObject ufo;            
    // 複製用のオブジェクト変数
    private GameObject ufo_copy;       
    // 時間のカウント
    private float time_count;          
    // 生成間隔
    private float generator_time;      
    // UFOのカウント
    private int ufo_count;             
    // UFOの生成する最大数
    private int ufo_max_count;         
    // シーンマネージャーの取得
    [SerializeField]
    private GameObject scene_manager;
    // シーンマネージャースクリプト
    private scene_manager scene_manager_script;
    // 初期化のスイッチ
    private bool initialization_switch;
    // 各ウェーブ最初の一体を出すときのスイッチ
    private bool first_pop;

    // Start is called before the first frame update
    void Start()
    {
        scene_manager_script = scene_manager.GetComponent<scene_manager>();
        UfoMaxCount(scene_manager_script.EnemyLevel());
        initialization_switch = false;
        first_pop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (scene_manager_script.GameMainSwitch() == true)
        {
            if (first_pop == true)
            {
                ufo_copy = Instantiate(ufo);
                ufo_count++;
                first_pop = false;
            }

            time_count += Time.deltaTime;

            Ufo_generator(scene_manager_script.EnemyLevel());
        }
        else
        {
            initialization();
        }
    }

    /// <summary>
    /// UFOの生成
    /// </summary>
    /// <param name="level">ウェーブ数</param>
    private void Ufo_generator(int level)
    {
        switch (level)
        {
            case 1: generator_time = 7; break;
            case 2: generator_time = 5; break;
            case 3: generator_time = 2; break;
        }

        if (time_count >= generator_time && ufo_count < ufo_max_count)
        {
            ufo_copy = Instantiate(ufo);
            ufo_count++;
            time_count = 0f;
        }
    }

    /// <summary>
    /// UFOがウェーブの中で最大何体でるかを決める
    /// </summary>
    /// <param name="level">ウェーブ数</param>
    private void UfoMaxCount(int level)
    {
        switch (level)
        {
            case 1: ufo_max_count = 3;  break;
            case 2: ufo_max_count = 6;  break;
            case 3: ufo_max_count = 10; break;
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void initialization()
    {
        first_pop = true;
        ufo_count = 0;
        UfoMaxCount(scene_manager_script.EnemyLevel()); 
    }

    /// <summary>
    /// UFOの数を減らす
    /// </summary>
    public void UfoMaxCountDown()
    {
        ufo_max_count--;
    }

    /// <summary>
    /// UFOの現在の数を返す
    /// </summary>
    /// <returns></returns>
    public int UfoMaxCount() { return ufo_max_count; }
}
