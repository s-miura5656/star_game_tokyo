using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo_generator : MonoBehaviour
{
    [SerializeField]
    private GameObject ufo;

    private GameObject ufo_copy;
    private float time_count;
    private float generator_time = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_count += Time.deltaTime;

        if (time_count >= generator_time)
        {
            ufo_copy = Instantiate(ufo);
            time_count = 0f;
        }
    }
}
