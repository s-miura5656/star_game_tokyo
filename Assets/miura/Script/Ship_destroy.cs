using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_destroy : MonoBehaviour
{
    // テキストマネージャーの取得
    [SerializeField]
    private GameObject text_manager;
    // テキストマネージャースクリプトの取得
    private Text_Manager text_script;
    // 生きているかどうか判断する変数
    private bool Alive_state;
    // シーンマネージャーの取得
    [SerializeField]
    private GameObject scene_manager;
    // シーンマネージャースクリプト
    private scene_manager scene_script;
    // 戦艦のテキストオブジェクトの取得
    [SerializeField]
    private GameObject text_obj;

    // Start is called before the first frame update
    void Start()
    {
        text_script = text_manager.GetComponent<Text_Manager>();
        Alive_state = true;
    }

    // Update is called once per frame
    void Update()
    {
        //AliveTiming();
    }

    /// <summary>
    /// 敵の攻撃にあったら消える
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            text_script.ShipCountDown();
            gameObject.SetActive(false);
            text_obj.SetActive(false);
            Alive_state = false;
        }
    }

    /// <summary>
    /// 生きているか破壊されたかを返す関数
    /// </summary>
    public bool Alive_or_dead() { return Alive_state; }

    /// <summary>
    /// 生き返るタイミング
    /// </summary>
    private void AliveTiming()
    {
        if (scene_script.InitializationSwitch() == true)
        {
            Alive_state = true;
        }
    }
}
