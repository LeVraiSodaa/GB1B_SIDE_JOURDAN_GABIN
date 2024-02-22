using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Référence à l'endroit où le joueur doit être téléporté
    public Transform teleportDestination;

    // Méthode appelée lorsqu'un objet entre en collision avec le téléporteur
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre en collision a le tag "Player" (ou tout autre tag que vous avez défini pour les objets à téléporter)
        if (other.CompareTag("Player"))
        {
            // Téléporte l'objet à la destination spécifiée
            other.transform.position = teleportDestination.position;
        }
    }
}
