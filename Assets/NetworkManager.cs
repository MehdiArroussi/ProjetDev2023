using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public GameObject player;
    public Transform startPoint;

    private void Awake(){
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion("eu");
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connecté");
        PhotonNetwork.JoinLobby();
    }

    void CreateRoom(){
        RoomOptions option = new RoomOptions();
        option.IsOpen = true;
        option.IsVisible = true;

        PhotonNetwork.JoinOrCreateRoom("HUB",option,null);
    }

    public override void OnJoinedLobby(){
        Debug.Log("Lobby joined");
        CreateRoom();
    }

    public override void OnJoinedRoom(){
        Debug.Log(PhotonNetwork.CurrentRoom.Name + " joined");
        PhotonNetwork.Instantiate(player.name,startPoint.position,Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
