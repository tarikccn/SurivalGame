using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree;

public class TreeScript : MonoBehaviour
{
    [SerializeField] private int treeHealth = 4;
    [SerializeField] GameObject stump;
    private Rigidbody treeRB;
    [SerializeField] GameObject tree;
    [SerializeField] Transform[] stumpPoints;
    [SerializeField] bool isBroken = false;
    [SerializeField] WeaponHit wh;
    public TreeBroken tb = new TreeBroken();

    [SerializeField] GameObject fallingRotation;
    void Start()
    {
        treeRB = GetComponent<Rigidbody>();
        treeHealth = 4;
    }
    void Update()
    {
        CutTree();
        BreakTree();
    }
    [SerializeField] int count = 0;
    public void TakeDamage(int damageAmount)
    {
        treeHealth -= damageAmount;
        if (treeHealth <= 0)
        {
            //Destroy(gameObject);
            isBroken = true;
            float x = Random.Range(-2, 2);
            float y = Random.Range(-2, 2);
            float z = Random.Range(-2, 2);
            Debug.Log("x: " + x + " y: " + y + " z: " + z);
            ForceTree(x, y, z);
        }
    }
    void BreakTree()
    {
        if (tb.isBroken)
        {
            count++;
            for (int i = 0; i < stumpPoints.Length; i++)
            {
                GameObject temp = Instantiate(stump, stumpPoints[i].position, Quaternion.LookRotation(fallingRotation.transform.up, Vector3.back));

            }
            tree.SetActive(false);
        }
    }

    void CutTree()
    {
        if (isBroken)
        {
            treeRB.isKinematic = false;
        }
        else
        {
            treeRB.isKinematic = true;
        }
    }
    [SerializeField] float force = 10f;
    void ForceTree(float x, float y, float z)
    {

        treeRB.AddForce(new Vector3(x, y, z) * force);

    }
}


