using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public float damage = 20f;
    public float range = 100f;

    public int maxAmmo = 15;
    private int currentAmmo;
    public float reloadTime = 10f;
    public float shootTime = 5f;
    private bool isReloading = false;
    private bool isShooting = false;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    Animator m_animator;

    private AudioSource soundEmitted;

    // Use this for initialization 
    private void Start()
    {
        // Get animator component for pistol, set max ammo and ability to make audio
        m_animator = GetComponent<Animator>();

        currentAmmo = maxAmmo;

        soundEmitted = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading) return;
        if (isShooting) return;

        // Starts reloading process
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        // Shoots the pistol
        if (Input.GetMouseButtonDown(0) && isShooting == false && currentAmmo > 0)
        {          
            StartCoroutine(Shoot());
            isShooting = true;
        } 
    }

    IEnumerator Shoot()
    {
        muzzleFlash.Play();
        m_animator.SetTrigger("Shoot");
        soundEmitted.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {   
            // Prints to the console what has been hit by the raycast
            Debug.Log(hit.transform.name);

            // If the raycast hits an enemy, it will take damage
            GetShot target = hit.transform.GetComponent<GetShot>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }   

        // Delay between shots, and subtracting the ammo count
        yield return new WaitForSecondsRealtime(shootTime);
        isShooting = false;
        currentAmmo--;       
    }

    IEnumerator Reload()
    {
        // Plays the reloading animation and reloads the gun while making sure the gun cannot fire while reloading
        isReloading = true;
        m_animator.SetTrigger("Reload");

        Debug.Log("Reloading...");

        yield return new WaitForSecondsRealtime(reloadTime);

        isReloading = false;
        currentAmmo = maxAmmo;
    }
}
