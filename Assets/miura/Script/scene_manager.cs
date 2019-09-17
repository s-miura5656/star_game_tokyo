using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class scene_manager : MonoBehaviour
{
    // ↓　表示切替するゲームオブジェクト
    [SerializeField]
    private GameObject text_manager;
    [SerializeField]
    private GameObject remaining_bullet_front_L;
    [SerializeField]
    private GameObject remaining_bullet_front_R;
    [SerializeField]
    private GameObject remaining_bullet_back_L;
    [SerializeField]
    private GameObject remaining_bullet_back_R;
    [SerializeField]
    private GameObject Title_;
    [SerializeField]
    private GameObject Description;
    [SerializeField]
    private GameObject attack_area;
    [SerializeField]
    private GameObject object_manager;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private GameObject gameover_fade_out;
    [SerializeField]
    private GameObject Ship_front_left;
    [SerializeField]
    private GameObject Ship_front_right;
    [SerializeField]
    private GameObject Ship_back_left;
    [SerializeField]
    private GameObject Ship_back_right;
    [SerializeField]
    private GameObject wave;
    [SerializeField]
    private GameObject game_clear;
    [SerializeField]
    private GameObject wave_1;
    [SerializeField]
    private GameObject wave_2;
    [SerializeField]
    private GameObject wave_3;
    [SerializeField]
    private GameObject all;
    [SerializeField]
    private GameObject wave_score_one;
    [SerializeField]
    private GameObject wave_score_two;
    [SerializeField]
    private GameObject wave_score_three;
    [SerializeField]
    private GameObject bullet_bonus;
    [SerializeField]
    private GameObject ship_bonus;
    [SerializeField]
    private GameObject tap_start;
    // ↑　ここまで

    // ゲームのレベルを決める変数
    private int game_level;
    // 複製のスイッチステート
    private bool display_state;
    // ゲームシーン用列挙型変数
    public enum GameScene {
        Title,
        GameMain,
        Description,
        Interval_first,
        Interval_second,
        GameOver,
        Result
    }

    private GameScene scene_;

    // 次のウェーブに移行するための数値
    private int enemy_attack_max;
    // 敵の攻撃を落としたときにカウントされる変数
    private int enemy_attack_count;
    // ウェーブ数
    private int wave_level;
    // ウェーブ表示画面で使う時計のカウント用
    private float interval_count;
    // ウェーブ表示画面の表示時間
    private float interval_max = 4;
    // 入力の遊び
    private float wait_time;
    // 入力の遊びの最大時間
    private float wait_max = 1f;
    // ゲームメインに遷移したかどうか判断する変数
    private bool gamemain_switch;
    // オーディオソース
    private AudioSource[] AudioSources;
    private AudioSource audio_se;
    // 戦艦の初期位置
    private Vector3[] battleship_base_pos;
    // 初期化判断用
    private bool initialization_state;
    // UFOgeneratorスクリプトの取得
    private ufo_generator ufo_script;
    // 各戦艦の破壊されたときの処理のスクリプト取得
    private Ship_destroy destroy_script_fl;
    private Ship_destroy destroy_script_fr;
    private Ship_destroy destroy_script_bl;
    private Ship_destroy destroy_script_br;
    // タイトル画面プッシュ音
    [SerializeField]
    private AudioClip push_sound;
    // リザルト表示
    [SerializeField]
    private AudioClip result_sound;
    // ゲームオーバー
    [SerializeField]
    private AudioClip gameover_sound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSources = gameObject.GetComponents<AudioSource>();
        audio_se = gameObject.GetComponent<AudioSource>();
        ufo_script = object_manager.GetComponent<ufo_generator>();
        display_state = false;
        scene_ = GameScene.Title;
        wave_level = 1;
        gamemain_switch = false;
        AudioSources[0].Play();
        destroy_script_fl = Ship_front_left.GetComponent<Ship_destroy>();
        destroy_script_fr = Ship_front_right.GetComponent<Ship_destroy>();
        destroy_script_bl = Ship_back_left.GetComponent<Ship_destroy>();
        destroy_script_br = Ship_back_right.GetComponent<Ship_destroy>();
        initialization_state = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (scene_)
        {
            case GameScene.Title:              Scene_Title();           break;
            case GameScene.Description:        Scene_Description();     break;
            case GameScene.Interval_first:     Scene_interval_first();  break;
            case GameScene.GameMain:           Scene_Game_Main();       break;
            case GameScene.Interval_second:    Scene_interval_second(); break;
            case GameScene.GameOver:           Scene_Game_Over();       break;
            case GameScene.Result:             SceneResult();           break;
        }
    }

    /// <summary>
    /// タイトルのシーンの関数
    /// </summary>
    private void Scene_Title()
    {
        wait_time += Time.deltaTime;

        Title_.SetActive(true);
        tap_start.SetActive(true);

        if (wait_time > wait_max)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audio_se.PlayOneShot(push_sound);
                ShipInitialization();
                Title_.SetActive(false);
                tap_start.SetActive(false);
                wait_time = 0f;
                scene_ = GameScene.Description;
            }
        }
        
    }

    /// <summary>
    /// 操作説明のシーンの関数
    /// </summary>
    private void Scene_Description()
    {
        wait_time += Time.deltaTime;

        Description.SetActive(true);

        if (wait_time > wait_max)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audio_se.PlayOneShot(push_sound);
                Description.SetActive(false);
                AudioSources[0].Stop();
                AudioSources[1].Play();
                wait_time = 0f;
                scene_ = GameScene.Interval_first;
            }
        }
        
    }

    /// <summary>
    /// ゲームメインの前のウェーブ表示画面
    /// </summary>
    private void Scene_interval_first()
    {
        if (EnemyLevel() >= 3)
        {
            AudioSources[1].Stop();
            AudioSources[2].Play();
        }

        text_manager.SetActive(true);

        wave.SetActive(true);

        interval_count += Time.deltaTime;

        if (interval_count >= interval_max)
        {
            wave.SetActive(false);
            scene_ = GameScene.GameMain;
            interval_count = 0;
            gamemain_switch = true;
        }
    }

    /// <summary>
    /// ゲームメインに必要なオブジェクトを表示
    /// </summary>
    private void Scene_Game_Main()
    {
        if (display_state == false)
        {
            if (destroy_script_fl.Alive_or_dead() == true)
            {
                remaining_bullet_front_L.SetActive(true);
            }
            else
            {
                remaining_bullet_front_L.SetActive(false);
            }

            if (destroy_script_fr.Alive_or_dead() == true)
            {
                remaining_bullet_front_R.SetActive(true);
            }
            else
            {
                remaining_bullet_front_R.SetActive(false);
            }

            if (destroy_script_bl.Alive_or_dead() == true)
            {
                remaining_bullet_back_L.SetActive(true);
            }
            else
            {
                remaining_bullet_back_L.SetActive(false);
            }

            if (destroy_script_br.Alive_or_dead() == true)
            {
                remaining_bullet_back_R.SetActive(true);
            }
            else
            {
                remaining_bullet_back_R.SetActive(false);
            }

            attack_area.SetActive(true);

            WaveScore();

            initialization_state = false;
            display_state = true;
        }

        if (ufo_script.UfoState() == 0)
        {
            scene_ = GameScene.Interval_second;
        }
    }

    /// <summary>
    /// ゲームメイン後のレベル変更用の処理
    /// </summary>
    private void Scene_interval_second()
    {
        gamemain_switch = false;

        if (wave_level < 3)
        {
            text_manager.SetActive(false);
            wave_level++;
            display_state = false;
            scene_ = GameScene.Interval_first;
        }
        else
        {
            text_manager.SetActive(false);
            wave_score_three.SetActive(false);
            wave_level++;
            RemainingBulletInactive();
            attack_area.SetActive(false);
            audio_se.PlayOneShot(result_sound);
            scene_ = GameScene.Result;
        }
    }

    /// <summary>
    /// ゲームオーバーでの処理
    /// </summary>
    private void Scene_Game_Over()
    {
        if (AudioSources[1].isPlaying)
        {
            AudioSources[1].Stop();
            audio_se.PlayOneShot(gameover_sound);
            wave_score_one.SetActive(false);
            wave_score_two.SetActive(false);
            GameOverSetUp();
            RemainingBulletInactive();
        }
        else if (AudioSources[2].isPlaying)
        {
            AudioSources[2].Stop();
            audio_se.PlayOneShot(gameover_sound);
            wave_score_three.SetActive(false);
            GameOverSetUp();
            RemainingBulletInactive();
        }

        wait_time += Time.deltaTime;

        // GameObject型の配列cubesに、"box"タグのついたオブジェクトをすべて格納
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");

        // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
        // foreachは配列の要素の数だけループします。
        foreach (GameObject enemy in enemys)
        {
            // 消す！
            Destroy(enemy);
        }

        if (wait_time > wait_max)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialization_state = true;
                initializationGameOver();
                initialization();

                AudioSources[0].Play();
                scene_ = GameScene.Title;
            }
        }
    }

    /// <summary>
    /// リザルトでの処理
    /// </summary>
    private void SceneResult()
    {
        AudioSources[2].Stop();
        wait_time += Time.deltaTime;

        text_manager.SetActive(true);
        ResultSetUp();

        if (wait_time > wait_max)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialization_state = true;

                initializationResult();
                initialization();
                AudioSources[0].Play();
                scene_ = GameScene.Title;
            }
        }
    }

    /// <summary>
    /// 船の場所の初期化
    /// </summary>
    private void ShipInitialization()
    {
        Ship_front_left.SetActive(true);
        Ship_front_right.SetActive(true);
        Ship_back_left.SetActive(true);
        Ship_back_right.SetActive(true);
    }

    /// <summary>
    /// 戦艦の残弾すべての非表示
    /// </summary>
    private void RemainingBulletInactive()
    {
        remaining_bullet_front_L.SetActive(false);
        remaining_bullet_front_R.SetActive(false);
        remaining_bullet_back_L.SetActive(false);
        remaining_bullet_back_R.SetActive(false);
    }

    /// <summary>
    /// ゲームオーバー画面に必要なものを表示
    /// </summary>
    private void GameOverSetUp()
    {
        gameover_fade_out.SetActive(true);
        gameover.SetActive(true);
    }

    /// <summary>
    /// リザルトに必要なものを表示
    /// </summary>
    private void ResultSetUp()
    {
        game_clear.SetActive(true);
        wave_1.SetActive(true);
        wave_2.SetActive(true);
        wave_3.SetActive(true);
        bullet_bonus.SetActive(true);
        ship_bonus.SetActive(true);
        all.SetActive(true);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void initialization()
    {
        display_state = false;
        text_manager.SetActive(false);
        wave_level = 1;
        gamemain_switch = false;
        Ship_front_left.SetActive(false);
        Ship_front_right.SetActive(false);
        Ship_back_left.SetActive(false);
        Ship_back_right.SetActive(false);
    }

    /// <summary>
    /// ゲームオーバー用初期化
    /// </summary>
    private void initializationGameOver()
    {
        attack_area.SetActive(false);
        gameover_fade_out.SetActive(false);
        gameover.SetActive(false);
        wait_time = 0f;
    }

    /// <summary>
    /// リザルト用初期化
    /// </summary>
    private void initializationResult()
    {
        game_clear.SetActive(false);
        wave_1.SetActive(false);
        wave_2.SetActive(false);
        wave_3.SetActive(false);
        bullet_bonus.SetActive(false);
        ship_bonus.SetActive(false);
        all.SetActive(false);
        wait_time = 0f;
    }

    /// <summary>
    /// ウェーブ毎に表示するスコア
    /// </summary>
    private void WaveScore()
    {
        switch (EnemyLevel())
        {
            case 1: wave_score_one.SetActive(true); break;
            case 2: wave_score_one.SetActive(false); wave_score_two.SetActive(true); break;
            case 3: wave_score_two.SetActive(false); wave_score_three.SetActive(true); break;
        }
    }

    /// <summary>
    /// シーンを決めるナンバーを返す
    /// </summary>
    /// <param name="number">番号</param>
    public void SetGameScene(GameScene scene)
    {
        scene_ = scene;
    }

    /// <summary>
    /// 敵のボムが破壊されるたびに増えるウェーブクリア条件用カウント
    /// </summary>
    public void EnamyAttack()
    {
        enemy_attack_count++;
    }

    /// <summary>
    /// ウェーブレベルを確認する
    /// </summary>
    /// <returns></returns>
    public int EnemyLevel() { return wave_level; }

    /// <summary>
    /// ゲームメインの状態か確認する
    /// </summary>
    /// <returns></returns>
    public bool GameMainSwitch() { return gamemain_switch; }

    /// <summary>
    /// 初期化するかしないか
    /// </summary>
    /// <returns></returns>
    public bool InitializationSwitch() { return initialization_state; }
}
