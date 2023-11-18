using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    
    public Vector3 _offset;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

   
    void LateUpdate()
    {
        _offset = transform.position;
        _offset.x = Mathf.Max(_offset.x, player.position.x);
        transform.position = _offset;
    }
}
