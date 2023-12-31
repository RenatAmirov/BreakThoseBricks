using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpDrop : MonoBehaviour
{

    public BasePowerUp PowerUpPrefab;

    //OnCollision create the powerup
    void OnCollisionEnter2D(Collision2D c)
    {
        GameObject.Instantiate(PowerUpPrefab, this.transform.position, Quaternion.identity);
    }

}