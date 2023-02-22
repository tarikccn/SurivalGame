using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject axe;
    void Start()
    {
        anim = axe.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Hit();
    }
    

    void Hit()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("LeftClick", true);
            Debug.Log("Left Clikc"); 
        }else if(Input.GetKeyUp(KeyCode.Mouse0)) anim.SetBool("LeftClick", false);
    }
}
