using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrenadeLauncher : MonoBehaviour
{
    public int startingMunerOfGrenades = 3;
    int numGrenades  = 3;

    public Rigidbody grenadePrefab;
    public Transform spawnPosition;
    public float launchForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        numGrenades = startingMunerOfGrenades;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && numGrenades > 0)
        {
            numGrenades--;
            Rigidbody rb = Instantiate(grenadePrefab, spawnPosition.position,spawnPosition.rotation);
            rb.AddForce(spawnPosition.forward * launchForce, ForceMode.Impulse);
        }
    }
}
