using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public float damage = 20f;
    public float heal = 5f;
    public GameObject gameOver;
    public bool gameOverB;

    // Start is called before the first frame update
    void Start()
    {
        gameOverB = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damage);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Heal(heal);
        }

        if (healthAmount <= 0)
        {
            GameOver();
        }

        if (gameOverB == false)
        {
            Time.timeScale = 1f;
        }

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void GameOver()
    {
        gameOverB = true;
        Time.timeScale = 0f;
        gameOver.SetActive(true);

    }



}
