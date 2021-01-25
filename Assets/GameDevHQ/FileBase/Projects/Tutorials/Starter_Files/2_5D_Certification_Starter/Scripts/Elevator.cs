using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _floorDelayTimer = 0;
    [SerializeField] Transform[] _floors;
    [SerializeField] int _targetPos = 0;

    private void FixedUpdate() {
        ChangeFloors();
    }

    void ChangeFloors() {
        //TODO: Make elevator floors run in reverse instead of restarting at first floor

        if (transform.position == _floors[_targetPos].position) {
            _floorDelayTimer += Time.deltaTime;
            if(_floorDelayTimer >= 5f) {
                _targetPos++;
                _floorDelayTimer = 0;
            }
            
            if (_targetPos >= _floors.Length) {
                _targetPos = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _floors[_targetPos].position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            other.transform.SetParent(this.transform);
            Debug.Log("Player on Elevator!");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            other.transform.SetParent(null);
        }
    }
}
