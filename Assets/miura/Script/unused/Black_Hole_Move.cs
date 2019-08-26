using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Hole_Move : MonoBehaviour
{

    // マウスの位置座標を格納する変数
    private Vector3 position;
    
    // マウスのスクリーン座標をワールド座標に変換した位置座標を格納する変数
    private Vector3 screenToWorldPointPosition;
    
    // 速度を格納する変数
    private float speed = 0.01f;

    // Z軸修正の値
    private float z_modification = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move_Controller(speed, z_modification);
    }

    public void Move_Controller(float SPEED, float Z_MODIFICATION)
    {
        if (Input.GetMouseButton(0))
        {
            // マウス位置座標を格納する
            position = Input.mousePosition;  
        }

        // Z軸の修正
        position.z = Z_MODIFICATION;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

        // ワールド座標に変換されたマウス座標と追従させたいオブジェクトの距離を測り、それを割る速度したものを現在位置に加算していく
        gameObject.transform.position = Vector3.Lerp(this.transform.position, screenToWorldPointPosition, SPEED);
    }
}
