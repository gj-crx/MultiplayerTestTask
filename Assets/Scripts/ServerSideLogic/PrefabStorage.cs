using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Provides the access to prefabs
/// </summary>
public class PrefabStorage : MonoBehaviour
{
    public static GameObject PlayerPrefab { get; private set; }
    public static GameObject BulletPrefab { get; private set; }


    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        PlayerPrefab = playerPrefab;
        BulletPrefab = bulletPrefab;
    }
}
