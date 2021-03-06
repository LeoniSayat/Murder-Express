using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject _object;
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 3);
        Instantiate(_object, playerPos, Quaternion.identity);
    }
}
