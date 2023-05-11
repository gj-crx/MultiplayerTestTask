using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Stores and provides information about the game map
/// </summary>
public class MapInfoStorage : MonoBehaviour
{
    public static float MapRadius { get; private set; }

    [SerializeField] private float mapRadius = 10;

    private void Awake()
    {
        MapRadius = mapRadius;
    }
}
