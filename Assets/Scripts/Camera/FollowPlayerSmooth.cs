using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSmooth : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float FollowSpeed;

    private bool startSequenceOver = false;

    private void Start()
    {
        StartCoroutine(StartCameraSequence());
    }
    private void FixedUpdate()
    {       
        if(startSequenceOver) CalculatePositionWithConstantY();
    }
    //preserves the Y position of the camera
    private void CalculatePositionWithConstantY()
    {
        Vector3 newPosition = GetNewPosition();
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
    private Vector3 GetNewPosition()
    {
        return Vector3.Lerp(transform.position, playerTransform.position + offset, FollowSpeed * Time.deltaTime);    
    }
    private IEnumerator StartCameraSequence()
    {
        yield return new WaitForSeconds(1);

        float timer = 0;
        while (timer<2)
        {
            transform.position = GetNewPosition();
            timer += Time.deltaTime;
            yield return null;
        }
        startSequenceOver = true;
        
    }
}
