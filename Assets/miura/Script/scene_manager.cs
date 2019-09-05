using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject text_manager;
    [SerializeField]
    private GameObject object_manager;
    [SerializeField]
    private GameObject remaining_bullet_front_L;
    [SerializeField]
    private GameObject remaining_bullet_front_R;
    [SerializeField]
    private GameObject remaining_bullet_back_L;
    [SerializeField]
    private GameObject remaining_bullet_back_R;
    [SerializeField]
    private GameObject attack_area;
    [SerializeField]
    private GameObject Title_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Scene_Gamemain(true);
            Title_.SetActive(false);
        }
    }

    void Scene_Gamemain(bool switch_scene)
    {
        text_manager.SetActive(switch_scene);
        object_manager.SetActive(switch_scene);
        remaining_bullet_front_L.SetActive(switch_scene);
        remaining_bullet_front_R.SetActive(switch_scene);
        remaining_bullet_back_L.SetActive(switch_scene);
        remaining_bullet_back_R.SetActive(switch_scene);
        attack_area.SetActive(switch_scene);
    }
}
