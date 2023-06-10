using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    public void Map1(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
