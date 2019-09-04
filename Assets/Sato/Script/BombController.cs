using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public int interval;
    private float bomb_time;
    GameObject ufoobj;
    public float speed;
    private Vector3 tmp;
    private Renderer rend;





    // Start is called before the first frame update
    void Start()
    {






        // UFOの座標取得
        Vector3 tmp = GameObject.Find("UFO").transform.position;
        this.transform.position = tmp;

        // Mesh Renderer OFF
        rend = GetComponent<Renderer>();
        rend.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        bomb_time += Time.deltaTime;

        if (bomb_time >= interval)
        {
            // UFOとの親子解除
            this.gameObject.transform.parent = null;

            // Mesh Renderer ON
            rend.enabled = true;

            // 座標
            Vector3 endpos = new Vector3(-1.0f, 0.0f, -13.0f);

            //スピード
            float step = speed * Time.deltaTime;

            // 現在の座標から目的地に移動
            transform.position = Vector3.MoveTowards(this.transform.position, endpos, step);


        }
    }
}
