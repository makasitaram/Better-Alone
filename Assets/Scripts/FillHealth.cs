
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FillHealth : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    public float healthBonus = 15f;


    void Awake()
    {

        playerHealth = FindObjectOfType<PlayerHealth>();
        print("Lol " + playerHealth);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            Destroy(gameObject);

            playerHealth.currentHealth = playerHealth.currentHealth + healthBonus;
            if (playerHealth.currentHealth > playerHealth.maxHealth)
            {
                playerHealth.currentHealth = playerHealth.maxHealth;
            }

        }
    }
}
