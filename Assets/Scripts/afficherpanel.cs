using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class afficherpanel : MonoBehaviour
{
    [SerializeField]private GameObject option;
    [SerializeField]private GameObject mainpanel;
    // Start is called before the first frame update
    public enum PanelType
{
    Panel1,
    Panel2,
    // Ajoutez d'autres types de panels selon vos besoins
}
    void Start()
    {
        mainpanel.SetActive(true); // Pour afficher le panel
        option.SetActive(false);
    }
    public void button(){
        mainpanel.SetActive(false); // Pour afficher le panel
        option.SetActive(true);
    }
    public void retour()
    {
        mainpanel.SetActive(true); // Pour afficher le panel
        option.SetActive(false);
    }
    
}
