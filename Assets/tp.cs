using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // R�f�rence � l'endroit o� le joueur doit �tre t�l�port�
    public Transform teleportDestination;

    // M�thode appel�e lorsqu'un objet entre en collision avec le t�l�porteur
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre en collision a le tag "Player" (ou tout autre tag que vous avez d�fini pour les objets � t�l�porter)
        if (other.CompareTag("Player"))
        {
            // T�l�porte l'objet � la destination sp�cifi�e
            other.transform.position = teleportDestination.position;
        }
    }
}
