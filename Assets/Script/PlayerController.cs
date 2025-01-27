using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake() {
        instance = this;
    }
    public float speed;
    public CircleCollider2D pickupRange;
    public Animator anim;
    //public Weapon activeWeapon;
    public List<Weapon> unassignedWeapons, assignedWeapons;
    public int maxWeapons = 3;
    [HideInInspector]
    public List<Weapon> fullyLevelledWeapons = new List<Weapon>();
    void Start()
    {
        if(assignedWeapons.Count == 0)
        {
            AddWeapon(Random.Range(0,unassignedWeapons.Count));
        }
        speed = PlayerStatController.instance.moveSpeed[0].value;
        pickupRange.radius = PlayerStatController.instance.pickupRange[0].value;
        maxWeapons = Mathf.RoundToInt(PlayerStatController.instance.maxWeapons[0].value);
    }

    // Update is called once per frame
    void Update() {
        
    
    
       /* if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,speed * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,-speed * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }*/
        Vector3 moveInput = new Vector3(0,0,0);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if(moveInput.x != 0)
        {
            transform.localScale = new Vector3(moveInput.x,1,1);
        }
        moveInput.Normalize();
        transform.position += speed* moveInput * Time.deltaTime;
        
        
        
        if(moveInput != Vector3.zero)
        {
            anim.SetBool("isMoving", true);

        }else
        { 
            anim.SetBool("isMoving", false);
        }
        
    }
    public void AddWeapon(int weaponNumber)
    {
        if(weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);
            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }

    }
    public void AddWeapon(Weapon weaponTaked)
    {
        weaponTaked.gameObject.SetActive(true);
        assignedWeapons.Add(weaponTaked);
        unassignedWeapons.Remove(weaponTaked);

    }
    /*public void checkLevelMaxWeapon(Weapon usingWeapon)
    {
        if(usingWeapon.weaponLevel >= usingWeapon.state.Count-1)
        {
            fullyLevelledWeapons.Add(usingWeapon);
            assignedWeapons.Remove(usingWeapon);
        }
    }*/

}
    
   
       
    


