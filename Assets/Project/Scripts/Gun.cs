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
        m_animator = GetComponent<Animator>();

        currentAmmo = maxAmmo;

        soundEmitted = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading) return;
        if (isShooting) return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

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
            Debug.Log(hit.transform.name);
        }   
        yield return new WaitForSecondsRealtime(shootTime);
        isShooting = false;
        currentAmmo--;       
    }

    IEnumerator Reload()
    {
        isReloading = true;
        m_animator.SetTrigger("Reload");

        Debug.Log("Reloading...");

        yield return new WaitForSecondsRealtime(reloadTime);

        isReloading = false;
        currentAmmo = maxAmmo;
    }
}
