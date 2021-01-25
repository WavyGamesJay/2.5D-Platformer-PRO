using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform _targetA, _targetB;
    [SerializeField] float _speed = 2f;
    Transform _currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        _currentTarget = _targetA;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == _targetA.position) {
            _currentTarget = _targetB;
        }
        else if(transform.position == _targetB.position) {
            _currentTarget = _targetA;
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            other.transform.parent = null;
        }
    }
}
