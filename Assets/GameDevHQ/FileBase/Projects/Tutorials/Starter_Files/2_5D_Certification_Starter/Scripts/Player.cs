using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //speed
    //jump height
    //gravity
    //direction
    CharacterController _controller;
    Animator _anim;
    UIManager _uiManager;

    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _climbSpeed = 3f;
    [SerializeField] private float _jumpHeight = 20f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private int _money;
    [SerializeField] private bool _climbingLadder = false;

    private Vector3 _direction;
    private Vector3 _velocity;
    private bool _jumping = false;
    private bool _onLedge;
    private Ledge _activeLedge;
    private Ladder _activeLadder;

    // Start is called before the first frame update
    void Start() {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_controller == null) {
            Debug.LogError("Character Controller is NULL!");
        }
        if (_anim == null) {
            Debug.LogError("Animator is NULL!");
        }
        if (_uiManager == null) {
            Debug.LogError("UIManager is NULL!");
        }
    }

    // Update is called once per frame
    void Update() {
        CalculateMovement();

        if (_onLedge == true) {
            if (Input.GetKeyDown(KeyCode.E)) {
                _anim.SetTrigger("ClimbUp");
            }
        }

        
    }



    void CalculateMovement() {
        //if grounded
        //calculate movement direction based on user inputs
        //if jump
        //adjust jump height
        //move    


        if (_controller.isGrounded) {
            if (_jumping) {
                _jumping = false;
                _anim.SetBool("Jumping", _jumping);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                PlayerRoll();
            }

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

            _direction = new Vector3(0, 0, horizontalInput);

            _velocity = _direction * _speed;

            //what direction do we face
            //if direction.x > 0
            //then we face the right
            //else
            //we face the left

            if (horizontalInput != 0) {
                Vector3 facing = transform.localEulerAngles;
                facing.y = _direction.z > 0 ? 0 : 180;
                transform.localEulerAngles = facing;
            }



            if (Input.GetKeyDown(KeyCode.Space)) {
                if (horizontalInput == 0) {
                    _anim.SetTrigger("IdleJump");
                }
                else {
                    _velocity.y = _jumpHeight;
                    _jumping = true;

                    _anim.SetBool("Jumping", _jumping);
                }
               
            }

        }


        _velocity.y -= _gravity * Time.deltaTime;

        if (_climbingLadder) {
            _controller.Move(Vector3.up * _climbSpeed * Time.deltaTime);
        } else {
            _controller.Move(_velocity * Time.deltaTime);
        }


    }

    public void GrabLedge(Vector3 handPos, Ledge currentLedge) {
        _controller.enabled = false;
        _anim.SetBool("GrabLedge", true);
        _anim.SetBool("Jumping", false);
        _anim.SetFloat("Speed", 0f);
        _onLedge = true;
        transform.position = handPos;
        _activeLedge = currentLedge;
    }

    public void ClimbUpComplete() {
        transform.position = _activeLedge.GetStandPos();
        _anim.SetBool("GrabLedge", false);
        _controller.enabled = true;
    }

    public void CollectMoney(int money) {
        _money += money;
        _uiManager.UpdateMoneyDisplay(_money);
    }

    public void ClimbLadder(Ladder currentLadder) {
        _anim.SetBool("ClimbLadder", true);
        Debug.Log("Climbing Ladder");
        _climbingLadder = true;
        _activeLadder = currentLadder;
    }
    public void ClimbLadderToTop() {
        _anim.SetTrigger("ClimbingToTop");
        _controller.enabled = false;
    }
    public void ClimbToTopComplete() {
        transform.position = _activeLadder.GetStandPos();
        _anim.SetBool("ClimbLadder", false);
        _climbingLadder = false;
        _controller.enabled = true;
    }

    void PlayerRoll(){ 
        _anim.SetTrigger("PlayerRoll");
    }  


}
