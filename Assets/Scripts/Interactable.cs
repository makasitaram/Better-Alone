using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI pickUpText;
    [SerializeField] private TextMeshProUGUI maskEquippedText;
    [SerializeField] private GameObject canvas;
    private bool pickUpAllowed;
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        maskEquippedText.gameObject.SetActive(false);


    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Warrior"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Warrior"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;

        }
    }
    void PickUp()
    {
        pickUpText.gameObject.SetActive(false);
        pickUpAllowed = false;
        maskEquippedText.gameObject.SetActive(true);
        Destroy(gameObject);
        // TextMeshProUGUI text = GameObject.FindGameObjectWithTag("ObjectiveCanvas").transform.GetComponent.
    }


}
