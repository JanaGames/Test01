using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public string finalText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>()) 
        {
            EventsController.Instance.finalText = this.finalText;
            GameManager.Instance.EndGame();
        }
    }
}
