using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderLedge : MonoBehaviour
{


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Debug.Log("Player at end of ladder");
        }
    }
}
