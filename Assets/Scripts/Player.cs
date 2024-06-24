using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
public class Player : NetworkBehaviour
    [SerializeField] private float _force = 10f;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        var cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachine.Follow = transform;
        cinemachine.LookAt= transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 force = transform.forward * _force;
            _rb.AddForce(force, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("obstacle"))
        {
            Return(other.gameObject);
        }
    }

    private void Return(GameObject obj)
    {
        ObjectPool.Instance.ReturnOne(obj);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Destroy(other.gameObject, 1f);
    }
}