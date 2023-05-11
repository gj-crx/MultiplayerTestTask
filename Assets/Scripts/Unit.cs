using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IDamageable, IMoveable, IAbleToShoot
{
    public float HitPoints = 100;
    public float MoveSpeed = 4;
    public float Damage = 20;

    [SerializeField] private NetworkCharacterControllerPrototypeCustom characterController;

    private Vector3 lastMovedDirection = Vector3.zero;
    private const float bulletSpawnOffset = 0.5f;

    public void Move(Vector3 movementInput)
    {
        if (movementInput == Vector3.zero) return;

        Vector3 moveDirection = transform.right * movementInput.x + transform.up * movementInput.y;
        moveDirection = moveDirection.normalized * MoveSpeed;
        characterController.Move(moveDirection);
        characterController.Velocity = new Vector3(moveDirection.x, moveDirection.y, 0);

        lastMovedDirection = moveDirection;
    }

    public void Shoot()
    {
        Bullet newBullet = Networking.NetworkSpawner.SpawnObject(PrefabStorage.BulletPrefab, transform.position + lastMovedDirection * bulletSpawnOffset).GetComponent<Bullet>();
        newBullet.Damage = Damage;
        newBullet.Direction = lastMovedDirection;
    }

    public void TakeDamage(float incomingDamage)
    {
        HitPoints -= incomingDamage;
    }
}
