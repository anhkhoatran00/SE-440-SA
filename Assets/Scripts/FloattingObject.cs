using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloattingObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float underWaterDrag;
    [SerializeField] private float underWaterAngularDrag;
    [SerializeField] private float airDrag;
    [SerializeField] private float airAngularAngularDrag;
    [SerializeField] private float waterPower;
    [SerializeField] private Transform[] floatPoints;
    [SerializeField] private float pointUnderWaterCount;

    private Rigidbody _rb;
    private bool _isUnderWater;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        foreach (var point in floatPoints)
        {
            var diff = point.position.y - 0;
            if (diff < 0)
            {
                _rb.AddForceAtPosition(
                    Vector3.up * waterPower,
                    point.position,
                    ForceMode.Force);
                pointUnderWaterCount++;
                if (!_isUnderWater)
                {
                    _isUnderWater = true;
                    SetStage(true);
                }
            }
        }
    }


        private void SetStage(bool underWater)
        {
            if (underWater)
            {
                _rb.drag = underWaterDrag;
                _rb.angularDrag = underWaterAngularDrag;

            }
            else
            {
                _rb.drag = airDrag;
                _rb.angularDrag = airAngularAngularDrag;
            }
        }

    }

