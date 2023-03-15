using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryContentCreator : MonoBehaviour
{
    [SerializeField] private GameObject CollectionPrefab;
    [SerializeField] private int minCount = 1, maxCount = 5;

    private void Start()
    {
        BuildCollections();
    }

    private void BuildCollections()
    {
        int desiredCount = Random.Range(minCount, maxCount);
        for (int i = 0; i < desiredCount; i++) {
            Instantiate(CollectionPrefab, transform);
        }
    }
}
