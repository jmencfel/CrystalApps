using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    private void FixedUpdate()
    {
        if(transform.position.y < -2.0f)
        {
            Die();
        }
    }
    public void Die()
    {
        GameController.Instance.IncreaseDeathCount();
        transform.position = startPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Trap")
        {
            Die();
        }
    }
}
