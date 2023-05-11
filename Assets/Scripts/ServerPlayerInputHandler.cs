using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reacts for players inputs
/// </summary>
public class ServerPlayerInputHandler : NetworkBehaviour
{
    private IMoveable movementComponent;
    private IAbleToShoot shootingComponent;
    private void Awake()
    {
        movementComponent = GetComponent<IMoveable>();
        shootingComponent = GetComponent<IAbleToShoot>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            HandleMovement(networkInputData);
            HandleActions(networkInputData);
        }
    }
    private void HandleMovement(NetworkInputData networkInputData)
    {
        movementComponent.Move(networkInputData.MovementInput);
    }
    private void HandleActions(NetworkInputData networkInputData)
    {
        if (networkInputData.attackTriggerInput)
        {
            networkInputData.attackTriggerInput = false;
            shootingComponent.Shoot();
        }
    }
}
