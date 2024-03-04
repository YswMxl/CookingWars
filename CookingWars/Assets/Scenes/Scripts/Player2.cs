using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerControl
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        Vector3 playerInput = new Vector3
        {
            x = Input.GetAxisRaw("HorizontalP2"),
            y = 0,
            z = Input.GetAxisRaw("VerticalP2")
        };
        if (playerInput.magnitude > 1f)
        {
            playerInput.Normalize();
        }
        Vector3 movevector = transform.TransformDirection(playerInput);
        Movement(playerInput);
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.RightControl)) 
        {
            Check();
        }
    }
}
