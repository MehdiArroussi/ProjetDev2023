/*using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class CharacterLoader : MonoBehaviourPunCallbacks
{
    public GameObject characterPrefabA;
    public GameObject characterPrefabB;

    private void Start()
    {
        if (PhotonNetwork.LocalPlayer != null)
        {
            int playerID = PhotonNetwork.LocalPlayer.ActorNumber;
            LoadCharacter(playerID);
        }
    }

    private void LoadCharacter(int playerID)
    {
        if (playerID % 2 == 0)
        {
            // Charger le personnage A
            Instantiate(characterPrefabA, transform.position, Quaternion.identity);
        }
        else
        {
            // Charger le personnage B
            Instantiate(characterPrefabB, transform.position, Quaternion.identity);
        }
    }
}*/