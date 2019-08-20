using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour
{
    Plane plane = new Plane();

    void Start()
    {


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                Vector3 endVec = new Vector3(0.0f, angles.y, angles.z);

                GameObject newLine = new GameObject("Line");
                LineRenderer lRend = newLine.AddComponent<LineRenderer>();
                lRend.SetVertexCount(2);
                lRend.SetWidth(0.2f, 0.2f);
                Vector3 startVec = new Vector3(0.0f, 0.0f, 0.0f);
                lRend.SetPosition(0, startVec);
                lRend.SetPosition(1, endVec);
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

}