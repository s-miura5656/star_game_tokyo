using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Move : MonoBehaviour
{
    public GameObject tamaPrefab;
    private int frame = 0;
    private float time = 0.0f;
    Plane plane = new Plane();
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;
    private Vector3 clickPosition;
    float speed;
    Vector3 target;
    private ParticleSystem particle;

    //GameObject target;


    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
        particle.Stop();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            position = Input.mousePosition;
            position.z = 39.0f;
            screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 worldDir = ray.direction;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, screenToWorldPointPosition, 0.1f);

            float distance = Vector3.Distance(transform.position, screenToWorldPointPosition);

            if (distance <= 0.2f)
            {
                
                particle.Play();
                  
            }

            if(distance <= 0.1f)
            {
                Destroy(this.gameObject);
            }

            //if (transform.position == screenToWorldPointPosition)
            //{
            //    particle.Play ();
            //    if (this.transform.localScale.x <= 3.0f)
            //    {
            //        this.transform.localScale = new Vector3(
            //            this.transform.localScale.x + 0.01f,
            //            this.transform.localScale.x + 0.01f,
            //            this.transform.localScale.x);
            //    }

                //    if((this.transform.localScale.x >= 2.5f))
                //    {
                //        Destroy(this.gameObject);

                //    } 



                //}
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("enemy"))
    //    {
            
    //        Destroy(collision.gameObject);

    //        //GameObject tama = Instantiate(tamaPrefab) as GameObject;
    //        //tama.transform.position = new Vector3(0, 0, 0);
    //    }
    //}




}
