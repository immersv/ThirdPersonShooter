using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript : MonoBehaviour
{
    [SerializeField]
    [Range(0,2)]
    private float gunFireRate;
    private float timer;
    [SerializeField]
    int healthDamage = 1;
    public Transform gunTransformPoint;
    [SerializeField]
    private ParticleSystem gunShootParticleEffect;
    [SerializeField]
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //gunShootParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > gunFireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0;
                PlayerFireshoot();
                
            }
        }
    }

    private void PlayerFireshoot()
    {
        //Debug.DrawRay(gunTransformPoint.position, gunTransformPoint.forward * 100, Color.red, 1f);
        gunShootParticleEffect.Play();
        audioSource.Play();
        Ray ray = new Ray(gunTransformPoint.position,gunTransformPoint.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
            var health=hit.collider.GetComponent<EnemyHealth>();
            if(health!=null)
            health.OnDamage(healthDamage);
           // Destroy(hit.collider.gameObject);
          //  Debug.Log("I shot the target with a bullet");

        }
    }
}
