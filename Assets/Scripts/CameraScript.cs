using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerPos;


    private void LateUpdate()
    {
        if (playerPos != null)
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -10f);
        }
    }


}
