using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    public Vector3 startPos;
    Rigidbody rb;
    [Tooltip("Adjusts the thrust of the object.")]
    [Range(0, 100)]
    public float thrust = 10;
    public ScoreScript score;
    // Start is called before the first frame update
    void Start()
    {
        //Grab start position of object
        startPos = transform.position;
        //Use GetComponent to assign RigidBody
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero; //Vector3(0,0,0,);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ResetBoulder();
        }
    }

    void ResetBoulder()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero; //Vector3(0,0,0,);
        score.AddScore();
    }
}
