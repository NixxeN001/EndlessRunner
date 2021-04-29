using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f;
    private float gameTime;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, speed * Time.deltaTime);
        // StartCoroutine(RampSpeed());
        gameTime = Time.deltaTime;
        //CheckTime();
    }

    IEnumerator RampSpeed()
    {
        Debug.Log("Current speed is: " + speed + "km/h");


        yield return new WaitForSeconds(1);

        speed = speed + 5f;
    }

    private void CheckTime()
    {
        if (gameTime <= Time.deltaTime + 1)
        {
            StartCoroutine(RampSpeed());
        }

    }


}
