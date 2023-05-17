using UnityEngine;
using TMPro;

namespace script
{
    public interface GunInfo
    {
        public void Shoot();
        public void Reload();
    }

    public class GunBasic : GunInfo
    {
        public int damage;
        public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
        public int magazineSize, bulletsPerTap;
        public bool allowButtonHold;
        int bulletsLeft, bulletsShot;
        
        bool shooting, readyToShoot, reloading;
        public void Shoot()
        {
            
        }

        public void Reload()
        {
            
        }
    }
}
// //Reference
// public Camera fpsCam;
// public Transform attackPoint;
// public RaycastHit rayHit;
// public LayerMask whatIsEnemy;
//
// //Graphics
// public GameObject muzzleFlash, bulletHoleGraphic;
// public float camShakeMagnitude, camShakeDuration;
// public TextMeshProUGUI text;



//     
//
//     private void Awake()
//     {
//         bulletsLeft = magazineSize;
//         readyToShoot = true;
//     }
//     private void Update()
//     {
//         MyInput();
//
//         //SetText
//         text.SetText(bulletsLeft + " / " + magazineSize);
//     }
//     private void MyInput()
//     {
//         if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
//         else shooting = Input.GetKeyDown(KeyCode.Mouse0);
//
//         if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
//
//         //Shoot
//         if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
//             bulletsShot = bulletsPerTap;
//             Shoot();
//         }
//     }
//     private void Shoot()
//     {
//         readyToShoot = false;
//
//         //Spread
//         float x = Random.Range(-spread, spread);
//         float y = Random.Range(-spread, spread);
//
//         //Calculate Direction with Spread
//         Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);
//
//         //RayCast
//         if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
//         {
//             Debug.Log(rayHit.collider.name);
//
//             if (rayHit.collider.CompareTag("Enemy"))
//                 rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
//         }
//         
//         //ShakeCamera
//         // camShake.Shake(camShakeDuration, camShakeMagnitude);
//
//         //Graphics
//         Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
//         Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
//
//         bulletsLeft--;
//         bulletsShot--;
//         Debug.Log("shooting");
//         Invoke("ResetShot", timeBetweenShooting);
//
//         if(bulletsShot > 0 && bulletsLeft > 0)
//         Invoke("Shoot", timeBetweenShots);
//     }
//     private void ResetShot()
//     {
//         Debug.Log("resetshot");
//         readyToShoot = true;
//     }
//     private void Reload()
//     {
//         Debug.Log("reload");
//         reloading = true;
//         Invoke("ReloadFinished", reloadTime);
//     }
//     private void ReloadFinished()
//     {
//         Debug.Log("reloadfinished");
//         bulletsLeft = magazineSize;
//         reloading = false;
//     }
//
// }
// }