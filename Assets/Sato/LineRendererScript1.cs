using UnityEngine;
using System.Collections;

public class LineRendererScript1 : MonoBehaviour
{


    void Start()
    {
        
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            GameObject newLine = new GameObject("Line");
            LineRenderer lRend = newLine.AddComponent<LineRenderer>();
            lRend.SetVertexCount(2);
            lRend.SetWidth(0.2f, 0.2f);
            Vector3 startVec = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 endVec = Camera.main.ScreenToWorldPoint(mousePos);
            lRend.SetPosition(0, startVec);
            lRend.SetPosition(1, endVec);
            
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
