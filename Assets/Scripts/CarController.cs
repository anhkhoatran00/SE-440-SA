using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum WheelType
    {
        //phia truoc
        Front,
        //phia sau
        Rear
    }
    //cho phep thay doi
    [System.Serializable]
    //nhu class 
    public struct Wheel
    {
        public WheelType type;
        public WheelCollider collider;
        public Transform transform;
        //public class CarController : MonoBehaviour { }
    }
    //giam sat 4 banh xe 
    [SerializeField] private List<Wheel> wheels = new List<Wheel>();
    // Start is called before the first frame update
    [SerializeField] private float speed = 50f;
    [SerializeField] private float steerSpeed = 30f;
    [SerializeField] private float maxSteerAngle = 30f;
    [SerializeField] private Vector3 centerOfMass;
    private float _moveInput;
    private float _steerInput;
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = Input.GetAxis("Vertical");
        _moveInput = Input.GetAxis("Horizontal");
        WheelAnimation();
        BrakeControl();
    }
    private void BrakeControl()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = 1000;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = 0;
            }
        }
    }
    private void WheelAnimation()
    {
        foreach (var wheel in wheels)
        {
            Vector3 pos;
            Quaternion rot;
            wheel.collider.GetWorldPose(out pos, out rot);
            wheel.transform.position = pos;
            wheel.transform.rotation = rot;

        }

        private void LateUpdate()
        {
            Move();
            Steer();
        }

        private void Move()
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.motorTorque = _moveInput * speed;
            }
        }
        private void Steer()
        {
            foreach (var wheel in wheels)
            {
                if (wheel.type == WheelType.Front)
                {
                    float steerAngle = _steerInput * maxSteerAngle * steerSpeed;
                    wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, steerAngle, 0.5f);
                }
            }

        }


    } }