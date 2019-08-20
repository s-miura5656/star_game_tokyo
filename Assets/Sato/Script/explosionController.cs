using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionController : MonoBehaviour
{
    int time = 180;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        time = time - 1;

        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.gameObject.tag == "enemy")
        {
            //
            //    Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            //    Vector3 force = new Vector3(3.0f, 0.0f, 0.0f);
            //    rb.AddForce(force);

            Destroy(obj.gameObject);
        }
    }
}
