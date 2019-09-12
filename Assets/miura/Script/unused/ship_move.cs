using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_controller : MonoBehaviour
{
    // 最初のy座標を下げる
    [SerializeField]
    private float y_pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShipMove();
    }

    // 戦艦の移動
    private void ShipMove()
    {
        if (transform.position.y <= y_pos)
        {
            transform.position += new Vector3(0f, Random.Range(0.02f, 0.04f), 0f);
        }
    }
}
