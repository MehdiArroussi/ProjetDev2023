using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    public string selectedMap;
    public GameObject selectedPlayer;

    private bool mapSelected = false;
    private bool playerSelected = false;

    public void SelectMap(string map)
    {
        selectedMap = map;
        mapSelected = true;

        CheckSelection();
    }

    public void SelectPlayer(GameObject player)
    {
        selectedPlayer = player;
        playerSelected = true;

        CheckSelection();
    }

    private void CheckSelection()
    {
        if (mapSelected && playerSelected)
        {
            SceneManager.LoadScene(selectedMap);
        }
    }
}
