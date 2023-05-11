using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listens for inputs from the local player and provides access for it to the server
/// </summary>
public class LocalPlayerInputSender : MonoBehaviour
{
    private Vector2 movementInputVector;
    private bool attackTriggerInput;

    private void Update()
    {
        movementInputVector.x = Input.GetAxis("Horizontal");
        movementInputVector.y = Input.GetAxis("Vertical");
        attackTriggerInput = Input.GetButtonDown("Fire1");
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.MovementInput = movementInputVector;
        networkInputData.attackTriggerInput = attackTriggerInput;

        return networkInputData;
    }
}
