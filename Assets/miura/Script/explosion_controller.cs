using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_controller : MonoBehaviour
{
    private bool explosion_switch;
    private float time;
    private float destroy_time = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= destroy_time)
        {
            Destroy(gameObject);
        }
    }

    
}
