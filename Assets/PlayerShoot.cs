using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
{
    private const string PLAYER_TAG = "Player";

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

    [Client]
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask) )
        {
            if(hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(hit.collider.name);
            }
            else
            {
                Debug.Log("Miss (Ground)");
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }

    [Command]
    void CmdPlayerShot(string id)
    {
        Debug.Log("Hit");
        Debug.Log(id + " has been shot.");
    }
}
