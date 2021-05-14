using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI healthPercentage;
    public float maxHealth = 100;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = maxHealth;
        currentHealth = healthBar.value;
    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage.text = currentHealth.ToString() + "%";
    }
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Virus" && healthBar.value > 0)
        {
            healthBar.value -= 5f;
            currentHealth = healthBar.value;
        }
        else
        {
            print("Player OnCollision");
            //Game End Screen
            // SceneManager.LoadScene("MainGame");
        }
    }

}
