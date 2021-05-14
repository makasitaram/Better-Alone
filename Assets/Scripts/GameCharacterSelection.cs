using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterSelection : MonoBehaviour
{
    // Start is called before the first frame update
    private int index;
    private GameObject[] myCharacters;

    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        myCharacters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            myCharacters[i] = transform.GetChild(i).gameObject;

        }
        foreach (GameObject go in myCharacters)
        {
            go.SetActive(false);
        }
        if (myCharacters[index])
        {
            myCharacters[index].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
