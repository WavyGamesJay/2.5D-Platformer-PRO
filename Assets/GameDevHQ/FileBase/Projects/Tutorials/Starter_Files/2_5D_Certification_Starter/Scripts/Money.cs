using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _cashAmount;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if(player != null) {
                player.CollectMoney(_cashAmount);
                Destroy(this.gameObject);
            }
               
        }
    }
}
