using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    private bool isPinned = false;
    
    public Rigidbody2D rb;
    public float speed = 20f;

    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!isPinned)
            rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
    }

    
}
