using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target1;
    public GameObject bullet1;


    Vector3 screenPoint;
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        screenPoint.y = 50.0f;
        transform.position = Camera.main.ScreenToWorldPoint(a);

        //if (Input.GetMouseButton(0))
        //{
        //    Instantiate(this.gameObject, Camera.main.ScreenToWorldPoint(screenPoint), this.gameObject.transform.rotation);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(true);
            //レイを投げて何かのオブジェクトに当たった場合
            if (Physics.Raycast(ray, out hit))
            {
                //レイが当たった位置(hit.point)にオブジェクトを生成する
                GameObject clonetarget = Instantiate(target1, hit.point, Quaternion.identity);
                GameObject clonebullet = Instantiate(bullet1, new Vector3(0.0f, 3.0f, -3.0f), Quaternion.identity);

                clonebullet.GetComponent<line>().obj = clonetarget;


            }
        }
    }


}

