using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject samouraiBPrefab;
    private bool samouraiBCreated = false; // Variable pour suivre si le SamouraiB a déjà été créé

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !samouraiBCreated) // Vérifier si le SamouraiB n'a pas encore été créé
        {
            Debug.Log($"Hey! {other.name} vient d'entrer dans la zone!");

            // Instancier un nouveau SamouraiB à la position de la zone
            GameObject newSamouraiB = Instantiate(samouraiBPrefab, transform.position, Quaternion.identity);
            samouraiBCreated = true; // Marquer que le SamouraiB a été créé
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Hey! {other.name} vient de quitter la zone!");

            // Supprimer le SamouraiB qui a quitté la zone
            Destroy(other.gameObject);
            samouraiBCreated = false; // Réinitialiser la variable pour permettre la création d'un nouveau SamouraiB
        }
    }
}
