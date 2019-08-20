using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    int move_state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;
        if (move_state == 0)
        {
            this.gameObject.transform.position = new Vector3(pos.x, pos.y , pos.z - 0.06f);

        }

    }
}
