using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f ;

    [SerializeField] int Hp;

    GameObject monsters;
    GameObject door;
    GameObject detection;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");

        Hp = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,moveSpeed*Time.deltaTime,0);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,-moveSpeed*Time.deltaTime,0);
        }
        else if(Input.GetKey("d"))
        {
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey("a"))
        {
            transform.Translate(-moveSpeed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey("w"))
        {
            transform.Translate(0,moveSpeed*Time.deltaTime,0);
        }
        else if(Input.GetKey("s"))
        {
            transform.Translate(0,-moveSpeed*Time.deltaTime,0);
        }
    } 

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "door")
        {
            Debug.Log("door");
            door = other.gameObject;
        }
        else if(other.gameObject.tag == "detection")
        {
            Debug.Log(other.contacts[0].point);
            Debug.Log("detection");
            detection = other.gameObject;
            detection.GetComponent<BoxCollider2D>().enabled = false;
        }
        //else if(other.gameObject.tag == "detection")
        //{
            //Debug.Log("closedoor");
            //door.GetComponent<BoxCollider2D>().enabled = true;
        //}

        else if(other.gameObject.tag == "bat")
        {
            Debug.Log("bat");
            monsters = other.gameObject;
        }
    }  

    void ModifyHp(int num)
    {
        Hp += num;
        if(Hp>100)
        {
            Hp = 100;
        }
        else if(Hp<0)
        {
            Hp = 0;
        }

    }

}