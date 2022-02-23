using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField]
    private float groundDestroyed;

    [SerializeField]
    private GameObject groundPrefab; 

    private const int MaxGrounds = 2;
    private List<GameObject> groundsInstanties;
    private float groundWidth;

    void Awake()
    {
        groundsInstanties = new List<GameObject>();
    }

    void Start()
    {
        groundWidth = groundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        groundsInstanties.Add(Instantiate(groundPrefab, new Vector3(0, -4.7f, 0), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        SpawnGround();
        DestroyGround();
    }

    private void DestroyGround()
    {
        var groundsToDestroy = groundsInstanties.Where(g => g.transform.position.x < groundDestroyed).ToList();
        foreach (var ground in groundsToDestroy)
        {
            groundsInstanties.Remove(ground);
            Destroy(ground);
        }
    }

    private void SpawnGround()
    {
        if (groundsInstanties.Count < MaxGrounds)
        {
            var ground = groundsInstanties.FirstOrDefault(g => g.transform.position.x  < 0);
            if (ground != null)
            {
                groundsInstanties.Add(Instantiate(groundPrefab, new Vector3(ground.transform.position.x + groundWidth - 10, ground.transform.position.y, 0), Quaternion.identity));
            }
        }
    }
}
