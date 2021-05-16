using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score_Check : MonoBehaviour
{
    public int scoreMultiplier = 1;

    [SerializeField] private LayerMask whatIsObstacle;
    private Game_Manager gm;

    private float tElapsed = 2;

    private void Start()
    {
        gm = GameObject.Find("Game_Manager").GetComponent<Game_Manager>(); 
    }

    private void FixedUpdate()
    {
        tElapsed += Time.deltaTime;
       
    }

    public void Hello()
    {
        Debug.Log("Hello");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (((whatIsObstacle.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)&& (tElapsed>= 0.5f))
        {
            gm.Score += 1 * scoreMultiplier;
            tElapsed = 0;
        }
    }

    public IEnumerator ResetScoreMultiplier(float t)
    {
        yield return new WaitForSeconds(t);
        scoreMultiplier = 1;
    }

}
