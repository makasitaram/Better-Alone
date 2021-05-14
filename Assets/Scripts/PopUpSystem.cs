using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;
using System.Linq;

public class PopUpSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject popUpBox;
    public GameObject dashBoard;



    public void PopUp()
    {
        if (popUpBox != null)
        {
            popUpBox.SetActive(true);
            dashBoard.SetActive(false);
        }


    }
    public void ClosePopUpBox()
    {
        if (popUpBox)
        {
            popUpBox.SetActive(false);
            dashBoard.SetActive(true);
        }
    }
}
