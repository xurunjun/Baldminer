using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject player;
    public GameObject GenerateManager;
    public void onClick()
    {
        Debug.Log("yesman");
        player.SetActive(true);
        GenerateManager.SetActive(true);
        gameObject.SetActive(false);
    }
}
