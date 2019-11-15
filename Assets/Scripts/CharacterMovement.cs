using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Character
{

    public class CharacterMovement : MonoBehaviour
    {
        Rigidbody2D myRigidBody2D;
        Animator myAnimator;
        Vector3 positionChange;
        [SerializeField] float speed = 1;

        // Start is called before the first frame update
        void Start()
        {
            myRigidBody2D = GetComponent<Rigidbody2D>();
            if (myRigidBody2D == null) Debug.Log("Whoops!  No RigidBody!");

            myAnimator = GetComponent<Animator>();
            if (myAnimator == null) Debug.Log("Whoops!  No Animator!");
        }

        // Update is called once per frame
        void Update()
        {
            positionChange = Vector3.zero;
            positionChange.x = Input.GetAxisRaw("Horizontal");
            positionChange.y = Input.GetAxisRaw("Vertical");

            Debug.Log(positionChange);
            if (positionChange != Vector3.zero)
            {
                Move();
                myAnimator.SetFloat("moveX", positionChange.x);
                myAnimator.SetFloat("moveY", positionChange.y);
                myAnimator.SetBool("isMoving", true);
            }
            else
            {
                myAnimator.SetBool("isMoving", false);
            }
        }

        private void Move()
        {
            myRigidBody2D.MovePosition(transform.position + (positionChange * speed * Time.deltaTime));
        }
    }
}