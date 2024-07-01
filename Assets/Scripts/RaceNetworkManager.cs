using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine;

public class RaceNetworkManager : NetworkManager
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] SpawnObstacle spawnObstacle;
    [SerializeField] private float spawnThresold = 3f;
    [SerializeField] private float countTime = 0;
    [SerializeField] private int maxConn = 1;
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        //base.OnServerAddPlayer(conn);
        Vector3 spawnPoint = spawnPoints[numPlayers].position;

        var player =
            Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);

    }

    private void FixedUpdate()
    {
        if (!isNetworkActive && numPlayers != maxConn) return;
        countTime += Time.fixedDeltaTime;
        if (countTime >= spawnThresold)
        {
            countTime -= spawnThresold;
            spawnObstacle.Spwan();
        }
    }
}
