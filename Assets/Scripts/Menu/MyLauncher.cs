using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;


public class MyLauncher : MonoBehaviourPunCallbacks
{
    public Button btn;
    public Text feedbackText;
    private byte maxPlayersPerRoom = 4;
   
    bool isConnecting;

    string gameVersion= "1";

    void Awake(){
           PhotonNetwork.AutomaticallySyncScene = true ;
     
    }

    public void Connect(){
        //feedbackText.text ="";
        isConnecting = true;
        btn.interactable = false;


        if (PhotonNetwork.IsConnected)
        {
            LogFeedback("Joining room...");
            PhotonNetwork.JoinRandomRoom();
        }
        else {
            LogFeedback("Connecting...");
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = this.gameVersion;
        }   
    }
    void LogFeedback(string message){
        if (feedbackText == null){
            return;
        }
        feedbackText.text += System.Environment.NewLine+message;
    }
    public override void OnConnectedToMaster(){
        if (isConnecting){
            LogFeedback("OnConnectedToMaster: Next -> try to join a room");
            Debug.Log("PUN Launcher");

            PhotonNetwork.JoinRandomRoom();
        }
    }
    public override void OnJoinRandomFailed(short returnCode, string message){
        PhotonNetwork.CreateRoom(null, new RoomOptions {
            MaxPlayers = this.maxPlayersPerRoom
        });
    }

    public override void OnDisconnected(DisconnectCause cause){
        LogFeedback("OnDisconnected" + cause);
        isConnecting = false;
        btn.interactable = true;
    }

    public override void OnJoinedRoom(){
        if (PhotonNetwork.CurrentRoom.PlayerCount ==1 ){
            PhotonNetwork.LoadLevel("Map Selection");
        }
    }
}