using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        transform.LookAt(target, Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ControlPoint>()!=null)
        {
            gameObject.SetActive(false);
        }
    }
}
