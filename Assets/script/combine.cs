using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combine : MonoBehaviour
{
    [Tooltip("Delay time before the result object spawns (in seconds)")]
    public float delay = 2.0f;

    [System.Serializable]
    public class Combination
    {
        public string material1;  // First material tag
        public string material2;  // Second material tag
        public GameObject resultPrefab;  // Resulting object prefab
    }

    [Tooltip("List of possible combinations")]
    public List<Combination> combinations = new List<Combination>();

    private Collider firstMaterial;
    private Collider secondMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (IsMaterial(other.tag))
        {
            if (firstMaterial == null)
            {
                firstMaterial = other; // Assign first material
            }
            else if (secondMaterial == null && other != firstMaterial)
            {
                secondMaterial = other; // Assign second material
                StartCoroutine(CombineMaterials());
            }
        }
    }

    private bool IsMaterial(string tag)
    {
        foreach (var combination in combinations)
        {
            if (tag == combination.material1 || tag == combination.material2)
                return true;
        }
        return false;
    }

    private IEnumerator CombineMaterials()
    {
        yield return new WaitForSeconds(delay);

        string tag1 = firstMaterial.tag;
        string tag2 = secondMaterial.tag;

        GameObject resultPrefab = FindCombination(tag1, tag2);
        if (resultPrefab != null)
        {
            // Calculate the spawn position (middle of the two objects)
            Vector3 spawnPosition = (firstMaterial.transform.position + secondMaterial.transform.position) / 2;

            // Destroy the original materials
            Destroy(firstMaterial.gameObject);
            Destroy(secondMaterial.gameObject);

            // Spawn the result object
            Instantiate(resultPrefab, spawnPosition, Quaternion.identity);
        }

        // Reset references
        firstMaterial = null;
        secondMaterial = null;
    }

    private GameObject FindCombination(string tag1, string tag2)
    {
        foreach (var combination in combinations)
        {
            if ((combination.material1 == tag1 && combination.material2 == tag2) ||
                (combination.material1 == tag2 && combination.material2 == tag1))
            {
                return combination.resultPrefab;
            }
        }
        return null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == firstMaterial)
        {
            firstMaterial = null;
        }
        else if (other == secondMaterial)
        {
            secondMaterial = null;
        }
    }
}
