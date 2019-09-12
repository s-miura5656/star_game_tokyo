using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_manager : MonoBehaviour
{
    public LinkedList<GameObject> planet_list = new LinkedList<GameObject>();

    GameObject enemy;

    float Pop_x_min = -5.0f;
    float Pop_x_max = 5.0f;
    float Pop_y = 13.0f;
    float Pop_z_min = -8.0f;
    float Pop_z_max = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Pop();

        Enemy_Pop();

        Enemy_Pop();

        Enemy_Pop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Enemy_Pop()
    {
        enemy = Instantiate((GameObject)Resources.Load("Stone"));
        enemy.transform.position = new Vector3(Random.Range(Pop_x_min, Pop_x_max), Pop_y, Random.Range(Pop_z_min, Pop_z_max));
        planet_list.AddFirst(enemy);
    }
}
