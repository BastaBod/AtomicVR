using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DESTROY : MonoBehaviour
{
    public float hitProjectiles=0;
    public float life;
    [SerializeField]
    private bool isBoss;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Slider easeHealthBar;
    [SerializeField]
    private Canvas UI;

    private void Update()
    {
        if (isBoss)
        {
            healthBar.value = (1.0f - (hitProjectiles / life));
            if (healthBar.value != easeHealthBar.value)
            {
                easeHealthBar.value = Mathf.Lerp(easeHealthBar.value,healthBar.value,0.025f);
            }
        }
        if (Input.GetKeyDown("o"))
        {
            PasStart();
        }
        if (hitProjectiles >= life)
        {
            PasStart();
        }
    }
   
    public void PasStart()
    {
        gameObject.BroadcastMessage("AutoDestroy", Camera.main.transform.forward);
        if(isBoss)
        UI.gameObject.SetActive(false);
    }

}
