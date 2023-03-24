using Unity.VisualScripting;
using UnityEngine;

public class PingPongLerpX : MonoBehaviour
{
    [SerializeField] private float _moveDistance = 5f; // distance to move back and forth
    [SerializeField] private float _moveSpeed = 1f; // speed of movement

    
    private Vector3 _maxPos;
    private Vector3 _minPos;

    void Start()
    {
        _maxPos = new Vector3(transform.localPosition.x + _moveDistance, transform.localPosition.y, transform.localPosition.z);
        _minPos = new Vector3(transform.localPosition.x - _moveDistance, transform.localPosition.y, transform.localPosition.z);
  
    }

    void Update()
    {
        // calculate the next position
        Vector3 displacement = new Vector3(_moveDistance, 0f, 0f);
        Vector3 nextPos = Vector3.Lerp(_maxPos, _minPos, Mathf.PingPong(Time.time * _moveSpeed, 1f));
        transform.localPosition = nextPos;
    }
}
