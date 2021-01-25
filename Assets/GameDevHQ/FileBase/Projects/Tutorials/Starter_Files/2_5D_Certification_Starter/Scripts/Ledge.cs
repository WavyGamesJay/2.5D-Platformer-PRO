using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    [SerializeField] private Transform _handPos;
    [SerializeField] private Transform _standPos;
    private void Start() {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ledge_Grab_Checker")) {
            Player player = other.GetComponentInParent<Player>();

            if(player != null) {
                player.GrabLedge(_handPos.position, this);
            }
        }
    }

    public Vector3 GetStandPos() {
        return _standPos.position;
    }
}
