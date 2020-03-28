using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AriePG {
    public class Player : MonoBehaviour {

        public Rigidbody2D rb;

        public float movementspeed = 1f;
        public Vector2 movement;

        private bool jump = false;
        private bool airborne = false;

        public Transform hand;
        public Bindings bindings;


        public bool busy = false;
        private Action currentAction;

        void Update() {

            movement = Vector2.zero;
            jump = false;

            
            foreach(Bindings.Binding binding in bindings.bindings) {
                if(!busy && Input.GetKey(binding.m_Key)) {
                    currentAction = binding.m_Action;
                    StartCoroutine(currentAction.Execute(this));
                }
            }


            movement = movement.normalized;

            if(!airborne) {
                if(Input.GetKey("space")) {
                    jump = true;
                }
            }

        }
        void FixedUpdate() {
            if(!airborne)
                rb.MovePosition(rb.position + movement * movementspeed * Time.deltaTime);
            if(jump) {

            }

        }
    }
}