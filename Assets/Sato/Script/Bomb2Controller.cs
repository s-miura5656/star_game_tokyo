using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2Controller : MonoBehaviour
{

    private float bomb2_time;
    public int interval2;
    private Renderer rend2;
    public float speed2;
    private Vector3 tmp2;
    GameObject ufoobj;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmp2 = GameObject.Find("UFO").transform.position;
        transform.position = tmp2;


        // Mesh Renderer OFF
        rend2 = GetComponent<Renderer>();
        rend2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        bomb2_time += Time.deltaTime;
        if (bomb2_time >= interval2)
        {
            // UFOとの親子解除
            this.gameObject.transform.parent = null;

            // Mesh Renderer ON
            rend2.enabled = true;

            // 座標
            Vector3 endpos = new Vector3(0.0f, -29.0f, 16.0f);

            //スピード
            float step2 = speed2 * Time.deltaTime;

            // 現在の座標から目的地に移動
            transform.position = Vector3.MoveTowards(this.transform.position, endpos, step2);

        }
    }
}
