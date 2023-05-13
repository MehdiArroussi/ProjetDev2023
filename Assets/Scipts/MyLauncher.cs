using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;


public class MyLauncher : MonoBehaviourPunCallbacks
{
    public Button btn;
    private Text text;
    private byte maxPlayersPerRoom = 4;

    bool isConnecting;

    string gameVersion = "1";

    void Awake(){
        PhotonNetwork.AutomaticallySyncScene = True;
    }

    public void Connect(){
        feedbackText ="";
        isConnecting = True;
        btn.interactable = false;
        if (PhotonNetwork.isConnecting)
        {
            LogFeedback("Joining room...");
            PhotonNetwork.JoinRandomRoom();
        }
        else {
            LogFeedback("Connecting...");
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.gameVersion = this.gameVersion;
        }   
    }
    void LogFeedback(string message){
        if (feedbackText == null){
            return;
        }
        feedbackText.text += System.Environment.Newline + message;
    }
}