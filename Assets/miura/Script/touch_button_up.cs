using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_button_up : MonoBehaviour
{
    [SerializeField]
    private GameObject obj_manager;
    private Black_hole_missile_manager bh_manager_script;
    // Start is called before the first frame update
    void Start()
    {
        bh_manager_script = obj_manager.GetComponent<Black_hole_missile_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickAct()
    {
        bh_manager_script.Missile_Start_Number(true);
    }
}
