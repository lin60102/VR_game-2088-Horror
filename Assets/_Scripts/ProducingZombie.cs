using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducingZombie : MonoBehaviour
{
    public GameObject ZombiePreb;
    private bool produceOne;
    private int TotalTime;

    void Start()
    {
        TotalTime = 100;
        produceOne = false;
    }


    void Update()
    {
        if (produceOne == false&&TotalTime==90)
        {
            StartCoroutine(ProduceZombies());
            produceOne = true;
            Debug.Log("timego");
        }

        StartCoroutine(CountDown());

        if (TotalTime < 80)
        {
            //Debug.Log("time");
            StartCoroutine(CountUp());
            produceOne = false;
        }
    }
    IEnumerator ProduceZombies()
    {
        yield return new WaitForSeconds(1);
        GameObject Zombies = Instantiate(ZombiePreb, transform.position, Quaternion.identity);
        TotalTime -= 10;
        yield return null;
    }
    IEnumerator CountDown()
    {
        while (TotalTime >= 0)
        {
           
            yield return new WaitForSeconds(1);
            TotalTime--;

        }
    }
    IEnumerator CountUp()
    {
        while (TotalTime <= 80)
        {

            yield return new WaitForSeconds(1);
            TotalTime++;

        }
    }
}
