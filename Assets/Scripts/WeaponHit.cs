using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tree
{
    public class WeaponHit : MonoBehaviour
    {
        private int damage = 1;
        private int treeHealth;
        private void Start()
        {
            //treeScript = new TreeScript();
            //treeHealth = treeScript[0].GetTreeHealth;
        }


        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent<TreeScript>(out TreeScript tree))
            {
                //tree.TakeDamage(1);
            }
        }
    }
}

