using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_Manager : MonoBehaviour
{
    // 残り弾数 前左のテキスト
    [SerializeField] 
    private GameObject remaining_bullet_front_L_text;
    // 残り弾数 前右のテキスト
    [SerializeField] 
    private GameObject remaining_bullet_front_R_text;
    // 残り弾数 後左のテキスト
    [SerializeField] 
    private GameObject remaining_bullet_back_L_text;
    // 残り弾数 後右のテキスト
    [SerializeField] 
    private GameObject remaining_bullet_back_R_text;
    // ウェーブ数のテキスト
    [SerializeField] 
    private GameObject wave_text;
    // ウェーブ１のスコアのテキスト
    [SerializeField]
    private GameObject wave1;
    // ウェーブ２のスコアのテキスト
    [SerializeField]
    private GameObject wave2;
    // ウェーブ３のスコアのテキスト
    [SerializeField]
    private GameObject wave3;
    // 全てのウェーブの合計のテキスト
    [SerializeField]
    private GameObject all;
    // 現在のウェーブのスコア
    [SerializeField]
    private GameObject wave_score;
    // コンボカウント
    private GameObject combo_count_text;
    // 残弾ボーナスのテキスト
    [SerializeField]
    private GameObject bullet_bonus;
    // 残存艦ボーナスのテキスト
    [SerializeField]
    private GameObject ship_bonus;
    // 戦艦前左
    [SerializeField]
    private GameObject ship_f_l;
    // 戦艦前右
    [SerializeField]
    private GameObject ship_f_r;
    // 戦艦後左
    [SerializeField]
    private GameObject ship_b_l;
    // 戦艦後右
    [SerializeField]
    private GameObject ship_b_r;
    // 各戦艦の残弾数
    [System.NonSerialized] // 前左
    public int bullet_count_front_L;
    [System.NonSerialized] // 前右
    public int bullet_count_front_R;
    [System.NonSerialized] // 後左
    public int bullet_count_back_L;
    [System.NonSerialized] // 後右
    public int bullet_count_back_R;

    // 残弾回復
    private float time;                       // 時間
    private float recharge_time = 10f;        // リチャージの時間

    // シーンマネージャーの取得
    [SerializeField]
    private GameObject scene_manager;

    // シーンマネージャーにアタッチしているスクリプト
    private scene_manager scene_manager_script;
    // 戦艦の数
    private int ship_count;
    // 戦艦のスコア
    private int ship_score;
    // コンボ用カウント
    private int combo_count;
    // 残弾の合計数
    private int all_bullet;
    // ウェーブ１の残弾
    private int all_bullet_one;
    // ウェーブ２の残弾
    private int all_bullet_two;
    // ウェーブ３の残弾
    private int all_bullet_three;
    // ウェーブ１合計スコア
    private int wave_one_score;
    // ウェーブ２合計スコア
    private int wave_two_score;
    // ウェーブ３合計スコア
    private int wave_three_score;
    // 合計スコア
    private int all_score_count;
    // スコア
    private int score;
    // コンボの受付時間
    private float combo_time;
    // コンボスイッチ
    private bool combo_switch;
    // 戦艦毎のスクリプト
    private Ship_destroy ship_script_f_l;
    private Ship_destroy ship_script_f_r;
    private Ship_destroy ship_script_b_l;
    private Ship_destroy ship_script_b_r;
    // 戦艦前の残弾の最大数
    private int front_bullet_max = 10;
    // 戦艦後の残弾最大数
    private int back_bullet_max = 5;
    // Start is called before the first frame update
    void Start()
    {
        combo_count_text = (GameObject)Resources.Load("combo_count");
        scene_manager_script = scene_manager.GetComponent<scene_manager>();
        ship_script_f_l = ship_f_l.GetComponent<Ship_destroy>();
        ship_script_f_r = ship_f_r.GetComponent<Ship_destroy>();
        ship_script_b_l = ship_b_l.GetComponent<Ship_destroy>();
        ship_script_b_r = ship_b_r.GetComponent<Ship_destroy>();
        ship_count = 4;
        bullet_count_front_L = 10;
        bullet_count_front_R = 10;
        bullet_count_back_L = 5;
        bullet_count_back_R = 5;
        combo_switch = false;
        combo_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Bullet_Gage_Front_L();
        Bullet_Gage_Front_R();
        Bullet_Gage_Back_L();
        Bullet_Gage_Back_R();
        WaveCount();
        WaveOneScore();
        WaveTwoScore();
        WaveThreeScore();
        AllScore();
        WaveScore();
        RemainingBulletBonus();
        ShipBonus();
        if (combo_switch == true)
        {
            ComboTime();
        }
    }

    /// <summary>
    /// 左前の戦艦の残弾の表示
    /// </summary>
    private void Bullet_Gage_Front_L()
    {
        Text _text = remaining_bullet_front_L_text.GetComponent<Text>();
        _text.text = "" + bullet_count_front_L;
    }

    /// <summary>
    /// 右前の戦艦の残弾の表示
    /// </summary>
    private void Bullet_Gage_Front_R()
    {
        Text _text = remaining_bullet_front_R_text.GetComponent<Text>();
        _text.text = "" + bullet_count_front_R;
    }

    /// <summary>
    /// 左後ろの戦艦の残弾の表示
    /// </summary>
    private void Bullet_Gage_Back_L()
    {
        Text _text = remaining_bullet_back_L_text.GetComponent<Text>();
        _text.text = "" + bullet_count_back_L;
    }

    /// <summary>
    /// 右後ろの戦艦の残弾の表示
    /// </summary>
    private void Bullet_Gage_Back_R()
    {
        Text _text = remaining_bullet_back_R_text.GetComponent<Text>();
        _text.text = "" + bullet_count_back_R;
    }

    /// <summary>
    /// ウェーブ数の表示 
    /// </summary>
    private void WaveCount()
    {
        Text _text = wave_text.GetComponent<Text>();
        _text.text = "Wave" + scene_manager_script.EnemyLevel();
    }

    /// <summary>
    /// ウェーブ１のスコア合計
    /// </summary>
    private void WaveOneScore()
    {
        Text _text = wave1.GetComponent<Text>();
        _text.text = "WAVE:1 SCORE " + wave_one_score;
    }

    /// <summary>
    /// ウェーブ２のスコア合計
    /// </summary>
    private void WaveTwoScore()
    {
        Text _text = wave2.GetComponent<Text>();
        _text.text = "WAVE:2 SCORE " + wave_two_score;
    }

    /// <summary>
    /// ウェーブ３のスコア合計
    /// </summary>
    private void WaveThreeScore()
    {
        Text _text = wave3.GetComponent<Text>();
        _text.text = "WAVE:3 SCORE " + wave_three_score;
    }

    /// <summary>
    /// スコアの合計
    /// </summary>
    private void AllScore()
    {
        Text _text = all.GetComponent<Text>();
        _text.text = "TOTAL SCORE " + all_score_count;
    }

    /// <summary>
    /// 残弾ボーナス
    /// </summary>
    private void RemainingBulletBonus()
    {
        Text _text = bullet_bonus.GetComponent<Text>();
        _text.text = "BULLET BONUS " + all_bullet;
    }

    /// <summary>
    /// 残存艦ボーナス
    /// </summary>
    private void ShipBonus()
    {
        Text _text = ship_bonus.GetComponent<Text>();
        _text.text = "SHIP BONUS " + ship_score;
    }

    /// <summary>
    /// 現在のウェーブの現在のスコア
    /// </summary>
    private void WaveScore()
    {
        Text _text = wave_score.GetComponent<Text>();

        switch (scene_manager_script.EnemyLevel())
        {
            case 1: _text.text = "" + wave_one_score;   break;
            case 2: _text.text = "" + wave_two_score;   break;
            case 3: _text.text = "" + wave_three_score; break;
        }
    }

    /// <summary>
    /// オブジェクトが非アクティブの時に残りの残弾を記憶する
    /// </summary>
    private void OnDisable()
    {
        BulletScoreCount();
        AllShipCount();
        AllScoreCount();
        BulletChageFrontLeft();
        BulletChageFrontRight();
        BulletChageBackLeft();
        BulletChageBackRight();

        if (scene_manager_script.InitializationSwitch() == true)
        {
            initialization();
        }
    }

    /// <summary>
    /// 残弾の合計の計算
    /// </summary>
    private void BulletScoreCount()
    {
        switch (scene_manager_script.EnemyLevel())
        {
            case 1: all_bullet_one = 500 * (bullet_count_front_L + bullet_count_front_R + bullet_count_back_L + bullet_count_back_R);   break;
            case 2: all_bullet_two = 500 * (bullet_count_front_L + bullet_count_front_R + bullet_count_back_L + bullet_count_back_R);   break;
            case 3: all_bullet_three = 500 * (bullet_count_front_L + bullet_count_front_R + bullet_count_back_L + bullet_count_back_R);
                    all_bullet = (all_bullet_one + all_bullet_two + all_bullet_three);                                                  break;
        }

    }

    /// <summary>
    /// ウェーブ１のスコア計算
    /// </summary>
    private void WaveOneScoreCount()
    {
        wave_one_score += score;
        score = 0;
    }

    /// <summary>
    /// ウェーブ２のスコア計算
    /// </summary>
    private void WaveTwoScoreCount()
    {
        wave_two_score += score;
        score = 0;
    }

    /// <summary>
    /// ウェーブ３のスコア計算
    /// </summary>
    private void WaveThreeScoreCount()
    {
        wave_three_score += score;
        score = 0;
    }

    /// <summary>
    /// 戦艦の残数スコア
    /// </summary>
    private void AllShipCount()
    {
        ship_score = 10000 * ship_count;
    }

    /// <summary>
    /// スコア合計の計算
    /// </summary>
    private void AllScoreCount()
    {
        all_score_count = (wave_one_score + wave_two_score + wave_three_score) + (ship_score) + (all_bullet);
    }

    /// <summary>
    /// コンボの受付時間
    /// </summary>
    private void ComboTime()
    {
        combo_time += Time.deltaTime;

        if (combo_time >= 0.7f) // コンボの時間を決めている場所
        {
            combo_switch = false;
            combo_count = 0;
            combo_time = 0f;
            
        }
    }

    /// <summary>
    /// スコアの初期化
    /// </summary>
    private void initialization()
    {
        ship_count = 4;
        bullet_count_front_L = 10;
        bullet_count_front_R = 10;
        bullet_count_back_L = 5;
        bullet_count_back_R = 5;
        combo_switch = false;
        combo_count = 0;
        wave_one_score = 0;
        wave_two_score = 0;
        wave_three_score = 0;
        ship_score = 0;
        all_bullet = 0;
        all_score_count = 0;   
    }


    // ↓他のスクリプトで使う関数↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    /// <summary>
    /// 左前の戦艦の残弾を減らす
    /// </summary>
    public void bullet_front_L_out()
    {
        bullet_count_front_L -= 1;
    }

    /// <summary>
    /// 右前の戦艦の残弾を減らす
    /// </summary>
    public void bullet_front_R_out()
    {
        bullet_count_front_R -= 1;
    }

    /// <summary>
    /// 左後ろの戦艦の残弾を減らす
    /// </summary>
    public void bullet_back_L_out()
    {
        bullet_count_back_L -= 1;
    }

    /// <summary>
    /// 右後ろの戦艦の残弾を減らす
    /// </summary>
    public void bullet_back_R_out()
    {
        bullet_count_back_R -= 1;
    }

    /// <summary>
    /// 戦艦の数を減らす
    /// </summary>
    public void ShipCountDown()
    {
        ship_count--;
    }

    /// <summary>
    /// コンボの計算
    /// </summary>
    public void ComboCountUp()
    {
        if (combo_count < 1)
        {
            score += 100;
        }
        else if (combo_count >= 1)
        {
            score += 100 * (2 * combo_count);
        }

        if (combo_count <= 5)
        {
            combo_count++;
        }

        combo_time = 0f;

        switch (scene_manager_script.EnemyLevel()) // ウェーブ数に応じて記録する場所を変える
        {
            case 1: WaveOneScoreCount();   break;
            case 2: WaveTwoScoreCount();   break;
            case 3: WaveThreeScoreCount(); break;
        }
    }

    /// <summary>
    /// コンボ用タイマーのスイッチオン
    /// </summary>
    public void ComboSwitchOn()
    {
        if (combo_switch == false)
        {
            combo_switch = true;
        }
    }

    /// <summary>
    /// 戦艦前左の弾回復
    /// </summary>
    public void BulletChageFrontLeft()
    {
        if (ship_script_f_l.Alive_or_dead() == true)
        {
            bullet_count_front_L = front_bullet_max;
        }
        else
        {
            bullet_count_front_L = 0;
        }
    }

    /// <summary>
    /// 戦艦前右の弾回復
    /// </summary>
    public void BulletChageFrontRight()
    {
        if (ship_script_f_r.Alive_or_dead() == true)
        {
            bullet_count_front_R = front_bullet_max;
        }
        else
        {
            bullet_count_front_R = 0;
        }
    }

    /// <summary>
    /// 戦艦後左の弾回復
    /// </summary>
    public void BulletChageBackLeft()
    {
        if (ship_script_b_l.Alive_or_dead() == true)
        {
            bullet_count_back_L = back_bullet_max;
        }
        else
        {
            bullet_count_back_L = 0;

        }
    }

    /// <summary>
    /// 戦艦後左の弾回復
    /// </summary>
    public void BulletChageBackRight()
    {
        if (ship_script_b_r.Alive_or_dead() == true)
        {
            bullet_count_back_R = back_bullet_max;
        }
        else
        {
            bullet_count_back_R = 0;

        }
    }

    /// <summary>
    /// コンボ数を参照する
    /// </summary>
    /// <returns></returns>
    public int ComboCount() { return combo_count; }
}
