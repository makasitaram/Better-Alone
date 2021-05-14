using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] myCharacters;
    // [SerializeField] private GameObject characterObject;
    // [SerializeField] private GameObject charactersParentObject;

    private int index;
    void Start()
    {


    }

    // Update is called once per frame


    public void CharacterSelected(int indexOfPlayer)
    {
        PlayerPrefs.SetInt("CharacterSelected", indexOfPlayer);
        SceneManager.LoadScene("MainGame");
        PlayerPrefs.Save();
    }


}
