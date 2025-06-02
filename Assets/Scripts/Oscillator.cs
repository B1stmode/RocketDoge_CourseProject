using UnityEngine;

public class Oscillator : MonoBehaviour
{

    [SerializeField ]Vector3 movementVector; 
    [SerializeField ]float speed;

    Vector3 startingPosition;
    Vector3 endPosition;
    float movementFactor;

    void Start()
    {
        startingPosition = transform.position;
        endPosition = startingPosition + movementVector;
    }

    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startingPosition, endPosition, movementFactor);
    }
}
