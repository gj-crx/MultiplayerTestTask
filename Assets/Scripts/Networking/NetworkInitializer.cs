using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Networking
{
    /// <summary>
    /// Starts server or a client
    /// </summary>
    public class NetworkInitializer : MonoBehaviour
    {
        [SerializeField] private NetworkRunner networkRunnerPrefab;
        [SerializeField] private NetworkSceneManagerDefault sceneManager;

        private NetworkRunner networkRunner = null;

        public NetworkRunner GetNetworkRunner() => networkRunner;

        private void Start() => InitializeNetworkRunner(GameMode.AutoHostOrClient, NetAddress.Any(), gameObject.scene.buildIndex, null);

        protected virtual Task InitializeNetworkRunner(GameMode gameMode, NetAddress addres, SceneRef scene, Action<NetworkRunner> initialized)
        {
            networkRunner = Instantiate(networkRunnerPrefab);
            networkRunner.name = "Network runner";
            networkRunner.gameObject.transform.SetParent(transform.parent);

            networkRunner.ProvideInput = true;

            return networkRunner.StartGame(new StartGameArgs
            {
                GameMode = gameMode,
                Address = addres,
                Scene = scene,
                SessionName = "Unnamed room",
                Initialized = initialized,
                SceneManager = sceneManager
            });
        }
    }
}
