using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    private Rigidbody2D bonusRigidBody2D;
    public string bonusAction = "Grow";

	void Start () {
        setVelocity();
    }
	
    private void setVelocity()
    {
        bonusRigidBody2D = GetComponent<Rigidbody2D>();
        bonusRigidBody2D.velocity = new Vector2(0, -2f);
    }
}
