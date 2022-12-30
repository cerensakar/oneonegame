using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawn : MonoBehaviour
{
    public GameObject pinPrefabs;
   
    void Update()
    {      
    if (Input.GetButtonDown("Fire1") && GameManager.Instance.currentState == GameManager.GameState.Gameplay) 
        {
      SpawnPin();
    }
    }
    void SpawnPin()
    {
      Instantiate(pinPrefabs, transform.position, transform.rotation);
    }
}
