using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {
    
public void Start() {
        
    }


    public void SceneLoad() {
        SceneManager.LoadScene("Loading");
    }
}