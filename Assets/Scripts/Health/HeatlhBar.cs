using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image curentheathBar;
    public GameObject healthBar;

    private void Update()
    {
        curentheathBar.fillAmount = playerHealth.currentHeatlh / 10;
        if (playerHealth.currentHeatlh <= 0)
            healthBar.SetActive(false);
           
    }

}
