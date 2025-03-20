using StarterAssets;
using UnityEngine;

/// <summary>
/// Handles using raycast to determine if the gun has shot the target
/// </summary>
public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int damageAmount = 1;

    StarterAssetsInputs starterAssetsInputs;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    /// <summary>
    /// Handles the logic of shooting at a target for the weapon
    /// </summary>
    void HandleShoot()
    {
        if(!starterAssetsInputs.shoot) return;

        muzzleFlash.Play();
        
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            // Looks for the enemyHealth component on the target shot at
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);

            starterAssetsInputs.ShootInput(false);
        }
    }
}
