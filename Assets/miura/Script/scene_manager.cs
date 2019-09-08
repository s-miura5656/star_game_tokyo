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
        GameOver
    }
    private GameScene scene_;

    // Start is called before the first frame update
    void Start()
    {
        display_state = false;
        scene_ = GameScene.Title;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (scene_)
        {
            case GameScene.Title:       Scene_Title();           break;
            case GameScene.Description: Scene_Description();     break;
            case GameScene.GameMain:    Scene_Game_Main();       break;
            case GameScene.GameOver:    Scene_Game_Over();       break;

        }
    }

    /// <summary>
    /// ゲームメインに必要なオブジェクトを表示
    /// </summary>
    private void Scene_Game_Main()
    {
        Level_Manager();

        if (display_state == false)
        {
            Ship_front_left.SetActive(true);
            Ship_front_right.SetActive(true);
            Ship_back_left.SetActive(true);
            Ship_back_right.SetActive(true);
            text_manager.SetActive(true);
            remaining_bullet_front_L.SetActive(true);
            remaining_bullet_front_R.SetActive(true);
            remaining_bullet_back_L.SetActive(true);
            remaining_bullet_back_R.SetActive(true);
            object_manager.SetActive(true);
            attack_area.SetActive(true);
            display_state = true;
        }
    }

    /// <summary>
    /// ゲームメインのレベルを管理する関数
    /// </summary>
    private void Level_Manager()
    {

    }

    /// <summary>
    /// タイトルのシーンの関数
    /// </summary>
    private void Scene_Title()
    {
        Title_.SetActive(true);
        
        if (Input.GetMouseButtonDown(0))
        {
            Title_.SetActive(false);
            scene_ = GameScene.Description;
        }
    }

    /// <summary>
    /// 操作説明のシーンの関数
    /// </summary>
    private void Scene_Description()
    {
        Description.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            Description.SetActive(false);
            scene_= GameScene.GameMain;
        }
    }

    /// <summary>
    /// ゲームオーバーの関数
    /// </summary>
    private void Scene_Game_Over()
    {
        gameover_fade_out.SetActive(true);

        if (display_state == true)
        {
            text_manager.SetActive(false);
            remaining_bullet_front_L.SetActive(false);
            remaining_bullet_front_R.SetActive(false);
            remaining_bullet_back_L.SetActive(false);
            remaining_bullet_back_R.SetActive(false);
            object_manager.SetActive(false);
            attack_area.SetActive(false);
            gameover.SetActive(true);
            display_state = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // GameObject型の配列cubesに、"box"タグのついたオブジェクトをすべて格納
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");

            // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject enemy in enemys)
            {
                // 消す！
                Destroy(enemy);
            }

            gameover_fade_out.SetActive(false);
            gameover.SetActive(false);
            Ship_front_left.SetActive(false);
            Ship_front_right.SetActive(false);
            Ship_back_left.SetActive(false);
            Ship_back_right.SetActive(false);

            scene_ = GameScene.Title;
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
}
