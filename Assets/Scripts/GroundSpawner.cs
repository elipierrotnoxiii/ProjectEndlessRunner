using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
   public Transform player;
    public float extendDistance = 5f; 

    private Vector3 initialScale;
    private Vector3 initialPosition;

    void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.position;
    }

    void Update()
    {
        float targetX = player.position.x + extendDistance;

       
        float currentRightEdge = transform.position.x + (transform.localScale.x / 2f);

        if (targetX > currentRightEdge)
        {
            float newWidth = targetX - transform.position.x;
            transform.localScale = new Vector3(newWidth * 2f, initialScale.y, initialScale.z);
        }
    }
}
