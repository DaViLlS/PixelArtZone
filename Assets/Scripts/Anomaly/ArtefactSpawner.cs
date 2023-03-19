using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactSpawner : MonoBehaviour
{
    [SerializeField] private Anmaly anomaly;
    [SerializeField] private GameObject prefItemWorld;
    [SerializeField] private int maxArtSpawn;
    private ArtefactSO[] artefactSOs;
    private int alreadySpawnedArts;

    private void Start()
    {
        artefactSOs = anomaly.artefacts;
        alreadySpawnedArts = 0;
        StartCoroutine(SpawnColdown());
    }

    private void SpawnArtefact()
    {
        int rand = Random.Range(0, 1);
        if (rand == 0)
        {
            if (alreadySpawnedArts <= maxArtSpawn)
            {
                alreadySpawnedArts++;
                int randomArt = Random.Range(0, artefactSOs.Length);

                float deltaX = Random.Range(-1, 1);
                float deltaY = Random.Range(-1, 1);

                ItemWorld tmpItem = Instantiate(prefItemWorld,
                    new Vector2(transform.position.x + deltaX, transform.position.y + deltaY), Quaternion.identity).GetComponent<ItemWorld>();
                tmpItem.itemSo = artefactSOs[randomArt];
            }
        }
    }

    IEnumerator SpawnColdown()
    {
        yield return new WaitForSeconds(10f);
        SpawnArtefact();
    }
}
