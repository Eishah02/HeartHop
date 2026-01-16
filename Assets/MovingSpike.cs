using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    public float speed = 2f;   // How fast it moves
    public float height = 0.5f; // How high it goes
    
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}