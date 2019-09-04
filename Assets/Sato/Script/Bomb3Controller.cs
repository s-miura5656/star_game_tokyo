using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb3Controller : MonoBehaviour
{

    private float bomb3_time;
    public int interval3;
    private Renderer rend3;
    public float speed3;
    private Vector3 tmp3;
    GameObject ufoobj;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmp3 = GameObject.Find("UFO").transform.position;
        transform.position = tmp3;


        // Mesh Renderer OFF
        rend3 = GetComponent<Renderer>();
        rend3.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        bomb3_time += Time.deltaTime;
        if (bomb3_time >= interval3)
        {
            // UFOとの親子解除
            this.gameObject.transform.parent = null;

            // Mesh Renderer ON
            rend3.enabled = true;

            // 座標
            Vector3 endpos = new Vector3(-1.0f, 0.0f, -13.0f);

            //スピード
            float step3 = speed3 * Time.deltaTime;

            // 現在の座標から目的地に移動
            transform.position = Vector3.MoveTowards(this.transform.position, endpos, step3);

        }
    }
}
