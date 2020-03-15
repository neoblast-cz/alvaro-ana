using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Start() {
        controller = GetComponent<CharacterController2D>();
    }

    void Update() {
        if (!DialogueController.instance.dialogueInProgress)
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        else horizontalMove = 0f;

        if (Input.GetButtonDown("Jump")) {
            if (DialogueController.instance.dialogueInProgress)
                DialogueController.instance.DisplayNextSentence();
            else {
                jump = true;
            }
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}