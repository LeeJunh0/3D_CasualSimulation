using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float followTime;

    private Vector3 offset = new Vector3(0, 9.89f, -9f);
    
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(playerPos.position.x + offset.x, offset.y, playerPos.position.z + offset.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, followTime);
    }
}
