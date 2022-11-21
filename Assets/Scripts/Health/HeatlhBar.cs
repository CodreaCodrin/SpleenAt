using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image curentheathBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHeatlh / 10;
    }
    private void Update()
    {
        curentheathBar.fillAmount = playerHealth.currentHeatlh / 10;
    }

}
