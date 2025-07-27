using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour
{
    [Header("Bullet")]
    public List<GameObject> BulletBarrels = new List<GameObject>();
    public GameObject BulletPrefab;
    public float BulletSpeed = 300f;
    public float BulletFireDelay = 0.15f;

    [Header("Rocket")]
    public List<GameObject> RocketBarrels = new List<GameObject>();
    public GameObject RocketPrefab;
    public float RocketSpeed = 175f;
    public float RocketFireDelay = 1f;

    private Coroutine shootingCoroutine = null;
    private Coroutine rocketCoroutine = null;

    public void UpdateWeapon(SpaceshipInput input)
    {
        if (input.FireBullet && shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(BulletShooting());
        }
        if (!input.FireBullet && shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }

        if (input.FireRocket && rocketCoroutine == null)
        {
            rocketCoroutine = StartCoroutine(RocketFiring());
        }
    }

    IEnumerator BulletShooting()
    {
        int barrelIndex = 0;
        while (true)
        {
            var barrel = BulletBarrels[barrelIndex % BulletBarrels.Count];
            GameObject bullet = Instantiate(BulletPrefab, barrel.transform.position, barrel.transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb) rb.AddForce(barrel.transform.forward * BulletSpeed, ForceMode.Impulse);
            barrelIndex++;
            yield return new WaitForSeconds(BulletFireDelay);
        }
    }

    IEnumerator RocketFiring()
    {
        int barrelIndex = Random.Range(0, RocketBarrels.Count);
        var barrel = RocketBarrels[barrelIndex];
        GameObject rocket = Instantiate(RocketPrefab, barrel.transform.position, barrel.transform.rotation);
        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        if (rb) rb.AddForce(barrel.transform.forward * RocketSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(RocketFireDelay);
        rocketCoroutine = null;
    }
}