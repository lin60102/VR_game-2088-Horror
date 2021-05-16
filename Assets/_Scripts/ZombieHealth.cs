using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : Subject
{
    public int Health = 1;
    //public Observer displayZombieHealth;

    private void Start()
    {
        //registerObserver(displayZombieHealth);
    }


    public void updateHealth(int life)
    {
        Health += life;
        Notify(Health, NotificationType.ZombieHealthUpdated);
    }
}
