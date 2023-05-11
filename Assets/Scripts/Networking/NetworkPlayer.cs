using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents player object across the network
/// </summary>
public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer LocalPlayer { get; private set; }
    

    public override void Spawned()
    {
        if (Object.HasInputAuthority) LocalPlayer = this;
    }
    public void PlayerLeft(PlayerRef player)
    {
        if (player == Object.InputAuthority) Runner.Despawn(Object);
    }
}
