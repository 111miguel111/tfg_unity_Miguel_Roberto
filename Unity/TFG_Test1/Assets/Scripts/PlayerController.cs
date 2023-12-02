using System.Threading;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody rb;
    private Vector3 displacement;
    void void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        float mh =Input.GetAxis("Horizontal");
        PlayerMove(mh);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayerMove(float mh)
    {
        displacement.Set(0f,0f,mh);
        displacement = displacement.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition (transform.position + displacement);
    }
}
