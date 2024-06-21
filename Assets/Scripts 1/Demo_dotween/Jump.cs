using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 3;
    [SerializeField] private float jumpTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            transform.DOJump(transform.position + jumpStep, jumpHeight, 1, jumpTime);
        }
    }
}