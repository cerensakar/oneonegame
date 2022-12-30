using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    public List<float> multiplier = new() {-1f, 1f};
    public float Speed
    {
        get => speed;
        set => speed = value * multiplier[Random.Range(0, 2)];
    }
    void Update()
    {
       transform.Rotate(0f, 0f, speed * Time.deltaTime);     
    }

    public void ChangeSpeed(float value)
    {
        speed = value * multiplier[Random.Range(0, 2)];
    }
}
