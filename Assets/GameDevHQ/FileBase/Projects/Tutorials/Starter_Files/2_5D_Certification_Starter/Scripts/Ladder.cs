using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    UIManager _uiManager;

    [SerializeField] Transform _standPos;
    

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        //if player enters ladder trigger
        //attach player to ladder
        //if player inside of laddder trigger
        //horizontal input greater than 0
        //climb up ladder && play climbing animation
        if(other.tag == "Player") {
            _uiManager.ShowControls();
            Player player = other.GetComponent<Player>();
            if(player != null) {
                Debug.Log("Player ready");
                if (Input.GetKeyDown(KeyCode.E)) {
                    //ClimbLadder
                    player.ClimbLadder(this);
                   
                }
                
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            _uiManager.HideControls();
        }
    }

    public Vector3 GetStandPos() {
        return _standPos.position;
    }
}
