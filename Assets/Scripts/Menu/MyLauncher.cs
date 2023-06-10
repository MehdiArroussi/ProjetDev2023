using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;


public class MyLauncher : MonoBehaviourPunCallbacks
{
    public bool overtime = false;
    public Button btn;
    public Text feedbackText;
    private byte maxPlayersPerRoom = 4;
    private Dictionary<int, string> playerIDs = new Dictionary<int, string>(); // Dictionnaire pour stocker les identifiants des joueurs

    public Dictionary<int, string> GetPlayerIDs()
    {
        return playerIDs;
    }

    bool isConnecting;

    string gameVersion = "1";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        //feedbackText.text ="";
        isConnecting = true;
        btn.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            LogFeedback("Rejoindre une salle...");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            LogFeedback("Connexion en cours...");
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = this.gameVersion;
        }
    }

    void LogFeedback(string message)
    {
        if (feedbackText == null)
        {
            return;
        }
        feedbackText.text += System.Environment.NewLine + message;
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            LogFeedback("Connecté au serveur : Tentative de rejoindre une salle");
            Debug.Log("PUN Launcher");

            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions
        {
            MaxPlayers = this.maxPlayersPerRoom
        });
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        LogFeedback("Déconnecté : " + cause);
        isConnecting = false;
        btn.interactable = true;
    }

    public override void OnJoinedRoom()
{
    if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
    {
        PhotonNetwork.LoadLevel("map1");
    }

    // Obtenir l'ID du joueur local
    int localPlayerID = PhotonNetwork.LocalPlayer.ActorNumber;

    // Vérifier si le nom du joueur local a été attribué
    if (!string.IsNullOrEmpty(PhotonNetwork.LocalPlayer.NickName))
    {
        string localPlayerName = PhotonNetwork.LocalPlayer.NickName;
        playerIDs.Add(localPlayerID, localPlayerName);
        Debug.Log("ID du joueur : " + localPlayerID + ", Nom : " + localPlayerName);
    }
    else
    {
        playerIDs.Add(localPlayerID, "Player " + localPlayerID);
        Debug.Log("ID du joueur : " + localPlayerID + ", Nom : Player " + localPlayerID);
    }
    }
}

