using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthbar;
    [SerializeField] float maxHealth = 500f;
    [SerializeField] float healthRegainAmount = 0.5f;
    [SerializeField] float healthRegainCooldown = 0.01f;
    [SerializeField] float currentHealth;
    float lastRegainTime;
    [SerializeField] int currentBlutegel;
    [SerializeField] TextMeshProUGUI blutegelText;

    [Header("Ibfection")]
    [SerializeField] Slider pestBar;
    [SerializeField] float maxInfection = 100f;
    [SerializeField] float currentInfection;








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        currentInfection = 0f;
        UpdateHealthBar();
        UpdatePestBar();
        UpdateBlutegelText();
 
        currentBlutegel = 0;

        // regain health
        lastRegainTime = -Mathf.Infinity;

    }


    void Update()
    {
        RegainHealth();

        if (Input.GetKeyDown(KeyCode.F))
        {
            UseBlutegel();
        }
    }


    // meths for healthBar
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamps the currentHealth between 0 and maxHealth

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (healthbar != null)
        {
            healthbar.value = currentHealth / maxHealth;
        }
    }

    public void RegainHealth()
    {
        if (currentHealth == maxHealth) return;

        if (Time.time - lastRegainTime >= healthRegainCooldown)
        {
            currentHealth += healthRegainAmount;
            lastRegainTime = Time.time;
            UpdateHealthBar();
        }

    }



    // meths for pestBar

    public void IncreaseInfection(float amount)
    {
        currentInfection += amount;
        currentInfection = Mathf.Clamp(currentInfection, 0, maxInfection);

        if (currentInfection >= maxInfection)
        {
            Die();
        }

        UpdatePestBar();
    }

    public void UpdatePestBar()
    {
        if (pestBar != null)
        {
            pestBar.value = currentInfection / maxInfection;
        }
    }

    // die
    public void Die()
    {

        Debug.Log("You Died.");
    }

    // getter
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetCurrentInfection()
    {
        return currentInfection;
    }

    public void SetValues(float healthAmount, float infectionAmount, int blutegel)
    {
        currentHealth = healthAmount;
        currentInfection = infectionAmount;
        currentBlutegel = blutegel;
        UpdateHealthBar();
        UpdatePestBar();
        UpdateBlutegelText();
    }

    public void AddBlutegel()
    {
        currentBlutegel++;
        UpdateBlutegelText();
    }
    public int GetCurrentBlutegel()
    {
        return currentBlutegel;
    }

    public void UseBlutegel()
    {
        if (currentBlutegel > 0)
        {
            currentBlutegel--;
            currentInfection -= 20f;
            UpdatePestBar();
            UpdateBlutegelText();
        }
    }

    public void UpdateBlutegelText()
    {
        blutegelText.text = $"X{currentBlutegel} use[F]";
    }
}
