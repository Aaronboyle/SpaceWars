using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private List<GameObject> playerShip;
    private int selectionNumber = 0;
    //default index of the model

    private void Start()
    {
        playerShip = new List<GameObject>();
        foreach (Transform t in transform)
        {
            playerShip.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        playerShip[selectionNumber].SetActive(true);
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.A))
            Select(1);
    }
    public void Select(int number)
    {
        if (number == selectionNumber)
            return;
        if (number < 0 || number >= playerShip.Count)
            return;
        playerShip[selectionNumber].SetActive(false);
        selectionNumber = number;
        playerShip[selectionNumber].SetActive(true);
        
    }

   
}
