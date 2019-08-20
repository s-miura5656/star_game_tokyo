//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TamaGenerator : MonoBehaviour
//{
//    float speed;
//    private ParticleSystem particle;
//    public float moveSpeed;
//    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
//    public float stopDistance;
//    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
//    public float moveDistance;

//    void Start()
//    {
//        particle = this.GetComponent<ParticleSystem>();
//        particle.Stop();
//    }

//    void Update()
//    {
//        Vector3 tmp = GameObject.Find("mose").transform.position;
//        float step = speed * Time.deltaTime;
//        transform.position = Vector3.MoveTowards(transform.position,
//           GameObject.Find("mose").transform.position, 0.1f);

//        //if(GameObject tama.position == ray)

//        float distance = Vector3.Distance(transform.position,
//            GameObject.Find("mose").transform.position);



//        if (distance < moveDistance && distance > stopDistance)
//        {
//            Destroy(gameObject);
//            particle.Play();

//        }
//    }
//}
