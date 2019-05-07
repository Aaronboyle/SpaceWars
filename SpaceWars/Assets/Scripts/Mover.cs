using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        //-negative velocty as the object was moving downwards
        GetComponent<Rigidbody>().velocity = - transform.right * speed;
    }
}