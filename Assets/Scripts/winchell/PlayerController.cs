using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace winchell
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 1;
        private Rigidbody2D rb;
        private Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            handleUserInput();
        }

        private void FixedUpdate()
        {
            
        }

        private void handleUserInput()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            rb.velocity = (new Vector2(horizontal, vertical)).normalized * movementSpeed;
            anim.SetFloat("velocity", rb.velocity.magnitude);
        }
    }
}