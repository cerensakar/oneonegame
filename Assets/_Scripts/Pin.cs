using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Pin : MonoBehaviour
{
    private bool isPinned = false;

    public float speed = 20f;
    public Rigidbody2D rb;
    public float rotateSpeed = 100f;
    public float rotateSpeedRange = 20;

    void FixedUpdate()
    {
        if (!isPinned)
            rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag == "Pin")
        {
            if (!isPinned)
                GetComponent<SpriteRenderer>().color = Color.red;

            FindObjectOfType<GameManager>().UpdateGameState(GameManager.GameState.GameOver);
        }

        if (collider.CompareTag("Rotator"))
        {
            transform.SetParent(collider.transform);
            float x = UnityEngine.Random.Range(-rotateSpeedRange, rotateSpeedRange);
            collider.GetComponent<Rotator>().ChangeSpeed(rotateSpeed + x);
            Score.PinCount--;
            if(Score.PinCount == 0)
                FindObjectOfType<GameManager>().UpdateGameState(GameManager.GameState.Continue);
            isPinned = true;
        }
    }
}
