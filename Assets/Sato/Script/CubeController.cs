using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
 
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            col.transform.parent = gameObject.transform;
            col.rigidbody.velocity = Vector3.zero;
            col.rigidbody.isKinematic = true;
            col.gameObject.GetComponent<move2>().enabled = false;


        }
    }
}
