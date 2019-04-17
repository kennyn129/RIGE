using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour {
    public int damage = 50;
    public float distance;
    public float maxDistance = 1.5f;
    public Transform weapon;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //Attack animation
            string[] punches = { "leftPunch", "rightPunch" };
            anim.SetTrigger(punches[Random.Range(0, punches.Length)]);
            //Attack function
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                if (distance < maxDistance)
                {
                    hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        anim.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            weapon.GetComponent<Animation>().CrossFade("Idle");
        }
	}
}
