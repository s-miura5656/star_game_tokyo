//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class teleportation : MonoBehaviour
//{
//    public float interval;
//    private float time;

//    public int manytime;
//    int time_state;
//    float bezier_t;

//    [SerializeField]
//    private float bullet_range = 5.0f;

//    private Vector3 bezier_start;
//    private Vector3 bezier_control1;
//    private Vector3 bezier_control2;
//    private Vector3 bezier_end;
//    //private bool pos = false;
//    GameObject bulletobj;
//    // Start is called before the first frame update

    
//    void Start()
//    {
//        bulletobj = GameObject.Find("bullet");
        
//        bezier_t = 0;
//        time_state = 0;
//        manytime = 0; 

//        time = 0.0f;
//        this.transform.position = new Vector3(Random.Range(-5.0f, 8.0f), 0, Random.Range(8.0f, 33.0f));
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (time_state == 0)
//        {
//            time += Time.deltaTime;
//            if (time >= interval)
//            {
//                this.transform.position = new Vector3(Random.Range(-8.5f, 8.0f), 0, Random.Range(6.0f, 33.0f));
//                time = 0.0f;

//                ++manytime;
//                if (manytime >= 4)
//                {
                    
//                    time_state = 1;
//                   time = 0.0f;
//                     bulletobj = GameObject.Find("bullet");
//                    bezier_end = bulletobj.transform.position + new Vector3(0, 0, 30);
//                    bezier_control1 = bulletobj.transform.position-new Vector3(0,0,5);
//                    bezier_control2 = bulletobj.transform.position;
//                    bezier_start = transform.position;

//                }
//            }
//        }

//        if (time_state == 1)
//        {
            

//            {
               





//                //this.transform.position = new Vector3(bulletobj.transform.position.x, bulletobj.transform.position.y , bulletobj.transform.position.z + bullet_range);

//                //if (!pos)
//                //{
//                    //bezier_end = bulletobj.transform.position + new Vector3(0,0,3);
//                    //pos = true;
//                //}


//                this.transform.position = Vector3Bezier(
//                bezier_start,
//                bezier_control1,
//                bezier_control2,
//                bezier_end, bezier_t);
//                bezier_t += 0.003f;



//                if (bezier_t >= 0.6f)
//                {
//                    time_state = 2;

//                    bulletController bullet_con = bulletobj.GetComponent<bulletController>();
//                    bullet_con.stop_switch(true);
//                    bulletobj.transform.parent = gameObject.transform;
//                }
//            }
            
//        }

//        if (time_state == 2)
//        {
//            //time += Time.deltaTime;
//            //if (time >= interval)
//            //{
//            //    time_state = 3;
//            //}

//            this.gameObject.transform.position = new Vector3(transform.position.x, 
//                                                             transform.position.y,
//                                                             transform.position.z + 0.1f);
//        }
//    }


//    Vector3 Vector3Bezier(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, float t)
//    {

//        float A1 = 1.0f - t;
//        float A2 = A1 * A1;
//        float A3 = A2 * A1;

//        float B1 = t;
//        float B2 = B1 * B1;
//        float B3 = B2 * B1;

//        Vector3 v = new Vector3();

//        v.x = A3 * start.x + 3 * A2 * B1 * control1.x + 3 * A1 * B2 * control2.x + B3 * end.x;
//        v.y = A3 * start.y + 3 * A2 * B1 * control1.y + 3 * A1 * B2 * control2.y + B3 * end.y;
//        v.z = A3 * start.z + 3 * A2 * B1 * control1.z + 3 * A1 * B2 * control2.z + B3 * end.z;

//        return v;

//    }

//}