using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]
    private float respawnRate = 2.0f;
    [SerializeField]
    private float randomRange = 1f;
    void Start()
    {
        StartCoroutine(spawner());
    }

    void createBall()
    {
        GameObject a = Instantiate(ball) as GameObject;
        float x_offset = Random.Range(-randomRange, randomRange);
        float z_offset = Random.Range(-randomRange, randomRange);
        a.transform.position = new Vector3(transform.position.x + x_offset, transform.position.y, transform.position.z + z_offset);
    }

    IEnumerator spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnRate);
            createBall();
        }
    }
}
