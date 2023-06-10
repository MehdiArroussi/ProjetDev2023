using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Manage : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefabA;
    public GameObject playerPrefabB;
    void Start()
    {
            MyLauncher launcher = FindObjectOfType<MyLauncher>();
            Dictionary<int, string> playerIDs = launcher.GetPlayerIDs();

            // Afficher les identifiants des joueurs dans la console
            foreach (KeyValuePair<int, string> playerID in playerIDs)
                Debug.Log("ID du joueur : " + playerID.Key + ", Nomaa : " + playerID.Value);

            if (playerIDs.ContainsKey(1))
            {
                // Instancier le personnage A pour le joueur avec l'ID 1
                PhotonNetwork.Instantiate(this.playerPrefabA.name, new Vector2(0, 0), Quaternion.identity, 0);
            }
            else if (playerIDs.ContainsKey(2))
            {
                // Instancier le personnage B pour le joueur avec l'ID 2
                PhotonNetwork.Instantiate(this.playerPrefabB.name, new Vector2(0, 0), Quaternion.identity, 0);
            }
        }
}
