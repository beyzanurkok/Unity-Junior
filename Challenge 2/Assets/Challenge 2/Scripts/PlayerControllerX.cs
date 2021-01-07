using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float spawnInterval = 1.0f;
    private float cooldown = 0.0f;

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && cooldown<=0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            cooldown = spawnInterval;
        }
    }
}
