using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbToTop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ledge_Grab_Checker"){
            Debug.Log("Player reached top of ladder");
            Player player = other.GetComponentInParent<Player>();
            if(player != null) {
                player.ClimbLadderToTop();
            }
        }
        
    }
}
