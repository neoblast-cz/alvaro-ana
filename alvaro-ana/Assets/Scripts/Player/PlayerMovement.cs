using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool dashDown = false;
    bool cannotJump = false;

    private bool playingmemories;

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }


    void Update() {
        if (!DialogueController.instance.dialogueInProgress && !playingmemories) {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetKeyDown(KeyCode.I)) {
                UIController.instance.InventorySwitch();
            }
        }
            
        else horizontalMove = 0f;

        if (Input.GetButtonDown("Jump")) {
            if (DialogueController.instance.dialogueInProgress)
                DialogueController.instance.DisplayNextSentence();
            else if (!cannotJump) {
                jump = true;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            dashDown = true;
        } else dashDown = false;
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        controller.DashDown(dashDown);
    }

    public void PlayingMemories() {
        playingmemories = !playingmemories;
    }

    public void CannotJump() {
        cannotJump = true;
    }

    public void SetSpeed(float newSpeed) {
        runSpeed = newSpeed;
    }
}