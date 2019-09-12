using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_ship_controller : MonoBehaviour
{
    [SerializeField]
    private float move_pos_y;
    private Vector3 base_pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShipMove();
    }

    /// <summary>
    /// 戦艦の移動
    /// </summary>
    private void ShipMove()
    {
        if (transform.position.y <= move_pos_y)
        {
            transform.position += new Vector3(0f, Random.Range(0.02f, 0.04f), 0f);
        }
    }

    private void OnEnable()
    {
        base_pos = transform.position;
    }

    private void OnDisable()
    {
        transform.position = base_pos;
    }
}
