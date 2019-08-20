using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public GameObject tamaPrefab;
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            GameObject tama = Instantiate(tamaPrefab) as GameObject;
            tama.transform.position = new Vector3(0, 0, 0);
        }

    }



}

