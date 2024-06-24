using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceNetworkManager : NetworkManager
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] spawnPoints;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        //base.OnServerAddPlayer(conn);

        int spawnIndex = numPlayers % spawnPoints.Length; // Use modulo to get valid index
        Vector3 spawnPoint = spawnPoints[spawnIndex].position;

        var player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }   
}
