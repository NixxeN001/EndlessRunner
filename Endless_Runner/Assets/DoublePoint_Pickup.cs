using System.Collections;
using UnityEngine;

public class DoublePoint_Pickup : Pickup
{
    public override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
    }

    public void StartEffect()
    {
        Score_Check scoreManager = GameObject.FindGameObjectWithTag("Score_Checker").GetComponent<Score_Check>();
        scoreManager.scoreMultiplier = 2;
        StartCoroutine(scoreManager.ResetScoreMultiplier(10));
        StartCoroutine(DelayDespawn(10));
    }

    IEnumerator DelayDespawn(float t)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(t);
        Object.Destroy(this.gameObject);
    }
}
