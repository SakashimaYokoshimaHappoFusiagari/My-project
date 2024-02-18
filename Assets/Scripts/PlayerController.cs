using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _moveVector;
    private float _fallVelocity = 1;
    private float _gravity = 9.8f;
    private CharacterController _charactercontroller;
    public float jumpForce;
    public float speed;
    void Start()
    {
        _charactercontroller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        _moveVector = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }    
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }    
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }    
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }    
        if (Input.GetKeyDown(KeyCode.Space) && _charactercontroller.isGrounded) {
            _fallVelocity = -jumpForce;
        }   
    }
    
    void FixedUpdate()
    {   
        _charactercontroller.Move(_moveVector * speed * Time.fixedDeltaTime); 
        
        _fallVelocity += _gravity * Time.fixedDeltaTime;
        _charactercontroller.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        
        if(_charactercontroller.isGrounded)
        {
            _fallVelocity = 0;
        }
        
                       
              
        
    }
}
