using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handscript : MonoBehaviour {

    //camera positions
    public Camera cam;
    Vector2 mousepos;
    Vector2 pos;
    float angle = 0f;
    public float direction = 0.5f;

    //sorting order
    private SpriteRenderer sprite;

    //referance to head
    public Rigidbody2D rbhead;

    //attack and equip
    private bool attack = false;
    public GameObject attackobject;
    public Sprite sword;

    public float defaultAngle = 15f;
    public float faseAngle = 15f;
    

    void Start () {
        sprite = GetComponent<SpriteRenderer>();
    }
	
	
	void Update () {

        attack = false;

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 lookDir = mousepos - rbhead.position;
        angle = (Mathf.Atan2(lookDir.y, lookDir.x)+direction*Mathf.PI);
        //Quaternion trans = transform.rotation;
        //trans.y = Mathf.Sin(angle * 0.5f);
        //transform.rotation = trans;

        //bool swap = Mathf.Abs(lookDir.normalized.x) > 0.5f;
        //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(lookDir.x) * (swap?-1:1), transform.localScale.y, 1);
        
        transform.rotation = Quaternion.Euler(0,0, Mathf.Sin((lookDir.normalized.x * 0.5f + 2) * Mathf.PI) * faseAngle + defaultAngle);

        Vector2 pos2 = rbhead.position;
        
        pos = pos2;
        pos.x += Mathf.Sin(angle - 0.5f * Mathf.PI) / (Mathf.PI*2f) + 0.01f;
        pos.y += -Mathf.Cos(angle - 0.5f * Mathf.PI) / (Mathf.PI * 6f) - 0.24f;


        if (Mathf.Sin(angle + (direction-0.5f) * Mathf.PI) >= 0 & direction <= 0 ^ Mathf.Sin(angle + (direction - 0.5f) * Mathf.PI) <= 0 & direction >= 0)
        {
            sprite.sortingOrder = 8;
        }
        else
        {
            sprite.sortingOrder = 11;
        }
        
        transform.position = pos;

        /*//attack and equip
        if (Input.GetKey("e"))
        {
            sprite.sprite = sword;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            attack = true;
        }
        if (attack == true)
        {
            attackobject = Instantiate(attackobject, transform.position, transform.rotation);
        }*/

    }

    void FixedUpdate()
    {
        
    }
}
