﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

enum CombatInputs
{
    primary,
    secondary
}

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    public bool DodgeInput { get; private set; }
    public bool DodgeInputStop { get; private set; }
    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;
    private float dashInputStartTime;
    private float dodgeInputStartTime;

    private bool activeInventory = true;
    private GameObject inventory;
    private void Start()
    {
        inventory = GameObject.Find("CharacterPanel");

        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];
    }
    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
        CheckDodgeInputHoldTime();

        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventory.SetActive(activeInventory);
        }
    }
    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }
    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }
    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }
        if (context.canceled)
        {
            GrabInput = false;
        }
    }
    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }
    public void OnDodgeInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DodgeInput = true;
            DodgeInputStop = false;
            dodgeInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            DodgeInputStop = true;
        }
    }
    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;
    public void UseDodgeInput() => DodgeInput = false;
    private void CheckJumpInputHoldTime()
    {
        if(Time.time >=jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
    private void CheckDodgeInputHoldTime()
    {
        if(Time.time >=dodgeInputStartTime + inputHoldTime)
        {
            DodgeInput = false;
        }
    }
}
