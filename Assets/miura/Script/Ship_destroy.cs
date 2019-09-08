using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_destroy : MonoBehaviour
{
    private bool Alive_state;
    // Start is called before the first frame update
    void Start()
    {
        Alive_state = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            gameObject.SetActive(false);
            Alive_state = false;
        }
    }

    /// <summary>
    /// 生きているか破壊されたかを返す関数
    /// </summary>
    public bool Alive_or_dead() { return Alive_state; }

    private void OnEnable()
    {
        Alive_state = true;
    }
}
