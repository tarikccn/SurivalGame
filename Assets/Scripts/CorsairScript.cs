using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CorsairScript : MonoBehaviour
{
    [SerializeField] private float rayLength = 10f;
    [SerializeField] private GameObject selectedGameObject;
    [SerializeField] private TMP_Text selectedObjectText;
    [SerializeField] private ParticleSystem particle;

    Vector3 particlePosition;
    bool isSelected = false;

    string[] selectableGameObjects = { "Tree", "Selectable" };
    void Start()
    {
        SeletctedObject();
        if (!isSelected)
        {
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SeletctedObject();
        StartCoroutine(TreeAttack());
    }

    IEnumerator TreeAttack()
    {
        if (Input.GetMouseButtonDown(0) && selectedGameObject != null)
        {
            Debug.Log("Hit");
            selectedGameObject.TryGetComponent<TreeScript>(out TreeScript tree);
            tree.TakeDamage(1);
            particle.transform.position = particlePosition;
            yield return new WaitForSeconds(0.5f);
            particle.Play();
        }    
    }
    void SeletctedObject()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        if (Physics.Raycast(ray, out hit) && hit.distance <= 2f && hit.distance >= 0.3f)
        {
            particlePosition = ray.origin + (ray.direction);
            Debug.Log("Hit Position: " + particlePosition);
            if (hit.collider.gameObject != selectedGameObject && ((hit.collider.gameObject.CompareTag(selectableGameObjects[0]) ||
                hit.collider.gameObject.CompareTag(selectableGameObjects[1]))))
            {
                
                selectedGameObject = hit.collider.gameObject;
                
                selectedObjectText.SetText(selectedGameObject.name);

                isSelected = true;
            }

        }
        else
        {
            selectedGameObject = null;
            selectedObjectText.SetText("");  
        }
    }
}




    




