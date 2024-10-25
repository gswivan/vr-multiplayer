using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class DesktopPlayer : NetworkBehaviour
{
    public GameObject Camera;

    private CharacterController controller;

    public void OnEnable()
    {
        Camera.SetActive(false);
        controller = GetComponent<CharacterController>();
    }

    public void SetLocal()
    {
        Camera.SetActive(true);
    }

    public override void FixedUpdateNetwork()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * 2.0f;
        controller.Move(move);
    }
}