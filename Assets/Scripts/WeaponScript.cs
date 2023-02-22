using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform axe;
    [SerializeField] private Transform eye;
    [Range (0,1)]
    [SerializeField] private float rotateSpeedSmooth = 0.125f;

    public Vector3 distanceOffset;


    private void Start()
    {
        axe = axe.gameObject.GetComponent<Transform>();
        eye = eye.gameObject.GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        moveWeapon();   
    }
    private void moveWeapon()
    {
        axe.transform.localPosition = eye.position + distanceOffset; 
        Quaternion targetRotation = Quaternion.LookRotation(eye.forward, Vector3.up);
        axe.rotation = Quaternion.Slerp(axe.rotation, targetRotation, 0.125f);
    }
}
