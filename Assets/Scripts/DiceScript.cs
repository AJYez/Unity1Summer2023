using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform throwPos;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        throwPos = GameObject.Find("ThrowPoint").transform;
        transform.rotation = Random.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.position = throwPos.position;
        rb.AddForce(new Vector3(Random.Range(-3, -7), 2, 0), ForceMode.Impulse);
    }
}
