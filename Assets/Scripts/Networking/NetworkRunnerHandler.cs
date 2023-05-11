using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking {
    public class NetworkRunnerHandler : MonoBehaviour, INetworkRunnerCallbacks
    {
        LocalPlayerInputSender inputHandler = null;
        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            if (runner.IsServer)
            {
                Debug.Log("Player connected ");

                NetworkSpawner.SpawnPlayerObject(player, runner);
            }
        }
        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {

        }


        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            if (inputHandler == null && NetworkPlayer.LocalPlayer != null)
                inputHandler = NetworkPlayer.LocalPlayer.GetComponent<LocalPlayerInputSender>();

            if (inputHandler != null)
            {
                input.Set(inputHandler.GetNetworkInput());
            };
        }




        public void OnConnectedToServer(NetworkRunner runner)
        {
            Debug.Log("Connected");
        }
        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
            Debug.LogError("Connection failed");
        }
        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
            Debug.Log("Connection requested");
        }



        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {

        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {

        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {

        }
        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {

        }
        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {

        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {

        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {

        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {

        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {

        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {

        }
    }
}
