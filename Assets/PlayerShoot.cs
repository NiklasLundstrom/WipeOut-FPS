using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
{
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    LayerMask mask;

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera reference!");
            this.enabled = false;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask) )
        {
            Debug.Log("We hit " + hit.collider.name);
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
