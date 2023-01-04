using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] WhichPrefab;
    public GameObject[] SpawnedItem;
    List<GameObject> Dupes = new List<GameObject>();
    public TMP_Text _CollectedItems;
    public static int itemCounter;
    public GameObject UI;
    public GameObject Joysticks;

    void Start()
    {
        NoDupes();
        // RemoveIfSpawned();
    }

    void Update()
    {
        WasCollected();
    }

    //Sets the stage for the items to be spawned in the predetermined locations, but in a random order.
    //In each location a different item will spawn each time.
    void Spawner()
    {
        var random = new System.Random();

        Dupes = Dupes.OrderBy(z => random.Next()).ToList();

        for (int i = 0; i < spawnLocations.Length; i++)
        {
            //Instantiate(Dupes[i], spawnLocations[i].transform.position, Quaternion.Euler(0,0,0));
            SpawnedItem [i] = Instantiate(Dupes[i], spawnLocations[i].transform.position, Quaternion.Euler(0,0,0));
            if (SpawnedItem[i].GetComponent<SceneButtonEnter>() != null)
            {
                SpawnedItem[i].GetComponent<SceneButtonEnter>().JoystickSet = Joysticks;
            }
        }
    }

    //Makes sure that not item is spawned more than once.
    void NoDupes()
    {
        for (int x = 0; x < WhichPrefab.Length; x++)
        {
            Dupes.Add(WhichPrefab[x]);
        }
        Spawner();
    }

    void WasCollected()
    {
        _CollectedItems.text = "ΑΝΤΙΚΕΙΜΕΝΑ: " + itemCounter + "/6";
        if (itemCounter == 6)
        {
            StartCoroutine(EnableEndGameUI());
        }
    }

    IEnumerator EnableEndGameUI()
    {
        yield return new WaitForSeconds(2);
        UI.SetActive(true);
    }
    // void RemoveIfSpawned()
    // {
    //     foreach (var x in SpawnedItem)
    //     {
    //         Debug.Log("SpawnedItem ID = " + x.name);
    //     }
    // }
}
