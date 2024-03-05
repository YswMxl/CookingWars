using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerControl
{
    void Update()
    {
        Vector3 playerInput = new Vector3
        {
            x = Input.GetAxisRaw("HorizontalP1"),
            y = 0,
            z = Input.GetAxisRaw("VerticalP1")
        };
        if (playerInput.magnitude > 1f)
        {
            playerInput.Normalize();
        }
        Vector3 movevector = transform.TransformDirection(playerInput);
        Movement(playerInput);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) 
        {
            Check();
        }
    }
}
