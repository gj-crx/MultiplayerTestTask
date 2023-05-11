using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    public static class NetworkSpawner
    {
        public static NetworkRunner Runner { private get; set; } = null;

        //Player handling
        public static void SpawnPlayerObject(PlayerRef ownerPlayer, NetworkRunner runner)
        {
            Runner = runner;
            Runner.Spawn(PrefabStorage.PlayerPrefab, GetRandomPositionForPlayer(), Quaternion.identity, ownerPlayer); //spawn and assign authority
        }
        public static GameObject SpawnObject(GameObject prefabToSpawn, Vector3 positionToSpawn)
        {
            if (Runner == null) return null;
            else return Runner.Spawn(prefabToSpawn, positionToSpawn, Quaternion.identity).gameObject; 
        }

        private static Vector3 GetRandomPositionForPlayer()
        {
            return new Vector3(UnityEngine.Random.Range(-MapInfoStorage.MapRadius, MapInfoStorage.MapRadius), UnityEngine.Random.Range(-MapInfoStorage.MapRadius, MapInfoStorage.MapRadius));
        }
    }
}
