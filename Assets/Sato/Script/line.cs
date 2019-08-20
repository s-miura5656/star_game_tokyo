using UnityEngine;
using System.Collections;

public class line : MonoBehaviour
{
    public GameObject obj;
    public float targetDistance;
    private ParticleSystem particle;

    public GameObject explosion;



    void Start()
    {
        //particle = this.GetComponent<ParticleSystem>();
        //particle.Stop();
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position,
                            obj.transform.position, 0.1f);

        float distance = (transform.position - obj.transform.position).sqrMagnitude;
        if (distance < targetDistance * targetDistance)
        {
            Destroy(gameObject);
            Destroy(obj);
            Instantiate(explosion, new Vector3(transform.position.x, 0.0f, transform.position.z), Quaternion.identity);
        }
    }
}