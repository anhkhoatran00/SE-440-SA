using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _force = 10f;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var force1 = Vector3.forward * _force;
            var force = transform.forward * _force;
            _rb.AddForce(force1, ForceMode.VelocityChange);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("obstacle"))
        {
            Debug.Log("Player collided with " + other.gameObject.name);
            Debug.Log("Player collided with force " + other.impulse);
            Debug.Log("Player collided with relative velocity" + other.relativeVelocity);
            Debug.Log("Player collided with contact points" + other.contacts[0].point);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Destroy(other.gameObject, 1f);
    }
}

