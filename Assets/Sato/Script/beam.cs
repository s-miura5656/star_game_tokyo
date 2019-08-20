using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour
{
    Plane plane = new Plane();
    void Start()
    {
//        Vector3 mousePosition = Input.mousePosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = this.gameObject.transform.position;
        
        if (Input.GetMouseButton(0))
        {
            float distance = 0;
            ///		// カメラとマウスの位置を元にRayを準備
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
            plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
            if (plane.Raycast(ray, out distance))
            {

                // 距離を元に交点を算出して、交点の方を向く
                var lookPoint = ray.GetPoint(distance);
                transform.LookAt(lookPoint);
                Vector3 angles = transform.eulerAngles;
                transform.eulerAngles = new Vector3(0.0f, angles.y, angles.z);
            }
        }

    }

    void OnParticleCollision(GameObject obj)
    {
        //処理内容
        //例）衝突したオブジェクトタグがenemyだった場合、オブジェクトを破壊する
        if (obj.gameObject.tag == "enemy")
        {
            Destroy(obj);
        }
    }

    //public class MouseSynchronizeObjectScript : MonoBehaviour
    //{
    //    // 位置座標
    //    private Vector3 position;
    //    // スクリーン座標をワールド座標に変換した位置座標
    //    private Vector3 screenToWorldPointPosition;
    //    // Use this for initialization

    //}
}
    