using UnityEngine;

public class CameraYLock : MonoBehaviour
{
   public Transform target;

    [SerializeField]
    private float fixedY;

    [SerializeField]
    private float fixedZ;

    [SerializeField]
    private float xOffset = -5f; 

    void Start()
    {
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x + xOffset, fixedY, fixedZ);
        }
    }
}
