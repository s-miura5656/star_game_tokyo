using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoController : MonoBehaviour
{

    public float ufo_speed;
    float bezier_t;
    private Vector3 bezier_start;
    private Vector3 bezier_control1;
    private Vector3 bezier_control2;
    private Vector3 bezier_end;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(16.0f, 1.3f, Random.Range(20.0f, 36.0f));
        bezier_start = new Vector3(16.0f, 1.3f, Random.Range(20.0f, 36.0f));
        bezier_control1 = new Vector3(7.0f, 1.3f, 17.0f);
        bezier_control2 = new Vector3(-5.0f, 1.3f, -1.0f);
        bezier_end = new Vector3(-21.0f, 1.3f, Random.Range(39.0f, 45.0f));
　　}

    // Update is called once per frame
    void Update()
    {
        // UFOの軌道 

        this.transform.position = Vector3Bezier(bezier_start,
               bezier_control1,
               bezier_control2,
                bezier_end,bezier_t);
        bezier_t += ufo_speed;

    }


    Vector3 Vector3Bezier(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, float t)
    {

        float A1 = 1.0f - t;
        float A2 = A1 * A1;
        float A3 = A2 * A1;

        float B1 = t;
        float B2 = B1 * B1;
        float B3 = B2 * B1;

        Vector3 v = new Vector3();

        v.x = A3 * start.x + 3 * A2 * B1 * control1.x + 3 * A1 * B2 * control2.x + B3 * end.x;
        v.y = A3 * start.y + 3 * A2 * B1 * control1.y + 3 * A1 * B2 * control2.y + B3 * end.y;
        v.z = A3 * start.z + 3 * A2 * B1 * control1.z + 3 * A1 * B2 * control2.z + B3 * end.z;

        return v;

    }
}
