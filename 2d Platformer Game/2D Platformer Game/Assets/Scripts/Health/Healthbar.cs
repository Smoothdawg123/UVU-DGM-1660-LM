
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{   public Health playerHealth;
    public Image totalhealthBar;
    public Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;

    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

}
