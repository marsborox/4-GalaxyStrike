using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    bool isfiring = false;

    private void Start()
    {
        //Cursor.visible = false;//disabled bcs it will disable cursor in editor and it pisses me off
    }
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveToTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value)
    { 
        isfiring = value.isPressed;
    }
    void ProcessFiring()
    {
        //Debug.Log("Fire");
        foreach (GameObject laser in lasers)
        {
            ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isfiring;
        }
    }
    void MoveCrosshair()
    { 
        crosshair.position = Input.mousePosition;
    }
    void MoveToTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        { 
            //Vector3 fireDirection = targetPoint.position - laser.transform.position;
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
    /*void ProcessFiring()
    {
        if (isfiring)
        {
            Debug.Log("Fire");
        }
    }*/
}
