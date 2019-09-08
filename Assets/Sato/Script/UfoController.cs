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

    private int random_number;
    // Start is called before the first frame update
    void Start()
    {
        random_number = Random.Range(0, 2);
        transform.position = new Vector3(0f, 25f, 0f);
        Wave_One(random_number);
    }

    // Update is called once per frame
    void Update()
    {
        UFO_Move();
        Destroy_UFO();
    }

    /// <summary>
    /// ベジェ曲線の関数
    /// </summary>
    /// <param name="start">始点</param>
    /// <param name="control1">中間点１</param>
    /// <param name="control2">中間点２</param>
    /// <param name="end">終点</param>
    /// <param name="t">進む割合</param>
    /// <returns></returns>
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

    private void Wave_One(int number)
    {
        switch (number)
        {
            case 0:
                bezier_start = new Vector3(16.0f, Random.Range(13f, 14f), 0f);
                bezier_control1 = new Vector3(Random.Range(2f, 7f), Random.Range(0f, 6f), 0f);
                bezier_control2 = new Vector3(Random.Range(-7f, -2f), Random.Range(0f, 6f), 0f);
                bezier_end = new Vector3(-16.0f, Random.Range(13f, 14f), 0f);
                break;
            case 1:
                bezier_start = new Vector3(-16.0f, Random.Range(13f, 14f), 0f);
                bezier_control1 = new Vector3(Random.Range(-7f, 0f), Random.Range(0f, 6f), 0f);
                bezier_control2 = new Vector3(Random.Range(0f, 7f), Random.Range(0f, 6f), 0f);
                bezier_end = new Vector3(16.0f, Random.Range(13f, 14f), 0f);
                break;
        }
        
    }

    /// <summary>
    /// UFOの破壊
    /// </summary>
    private void Destroy_UFO()
    {
        if (transform.position.y >= 27f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// UFOの軌道
    /// </summary>
    private void UFO_Move()
    {
        // UFOの軌道 
        transform.position = Vector3Bezier(bezier_start,
                                           bezier_control1,
                                           bezier_control2,
                                           bezier_end,
                                           bezier_t);

        bezier_t += ufo_speed;
    }
}
