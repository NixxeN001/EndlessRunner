using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private int currentLane = 0;
    private bool isTranstion = false;
    private GameObject player_obj;
    private float move_distance;
    public LayerMask obstacle;
    void Start()
    {
        player_obj = this.gameObject;
        player_obj.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move_Left();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move_Right();
        }


    }

    private void Move_Left()
    {

        move_distance = 3;
        if (currentLane != -1)
        {
            currentLane--;
            StartCoroutine(MoveSmooth(new Vector3(player_obj.transform.position.x - move_distance, player_obj.transform.position.y, player_obj.transform.position.z), player_obj.transform.position));
        }
        // Vector3 newPos = new Vector3(player_obj.transform.position.x - move_distance, player_obj.transform.position.y, player_obj.transform.position.z);
        // player_obj.transform.position = newPos;
        //  StartCoroutine(MoveSmooth(new Vector3(player_obj.transform.position.x - move_distance, player_obj.transform.position.y, player_obj.transform.position.z), player_obj.transform.position));

    }

    private void Move_Right()
    {
        move_distance = 3;
        if (currentLane != 1)
        {
            currentLane++;

            StartCoroutine(MoveSmooth(new Vector3(player_obj.transform.position.x + move_distance, player_obj.transform.position.y, player_obj.transform.position.z), player_obj.transform.position));
        }
    }
    IEnumerator MoveSmooth(Vector3 finalPos, Vector3 intialPos)
    {
        if (!isTranstion)
        {
            isTranstion = true;
            float t = 0;
            while (t < 0.09)
            {
                player_obj.transform.position = Vector3.Lerp(player_obj.transform.position, finalPos, t);
                t += Time.deltaTime;
                yield return null;
            }
            player_obj.transform.position = finalPos;
            isTranstion = false;
        }
    }




    private void OnTriggerEnter(Collider collision)
    {
        if ((obstacle.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            Object.Destroy(player_obj);
        }
    }
  


}
