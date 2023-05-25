using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float jumpHeight;
    public KeyCode jumpKey;

    public TextMeshProUGUI scoreText;

    private bool jumpIsReady = true;
    private Rigidbody rBody;
    private Vector3 startingPos;
    private int score = 0;
    public event Action OnReset;




    public void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        startingPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(jumpKey))
            Jump();
    }

    private void Jump()
    {
        if (jumpIsReady == true)
        {
            rBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.VelocityChange);
            jumpIsReady = false;
        }
    }

    private void Reset()
    {
        score = 0;
        scoreText.text = score.ToString();
        jumpIsReady = true;
        transform.position = startingPos;
        rBody.velocity = Vector3.zero;
        OnReset?.Invoke();
    }

    private void OnCollisionEnter(Collision collidedObj)
    {
        if (collidedObj.gameObject.CompareTag("ground"))
            jumpIsReady = true;
        else if (collidedObj.gameObject.CompareTag("Enemy"))
            Reset();
    }

    private void OnTriggerEnter(Collider collidedObj)
    {
        if (collidedObj.gameObject.CompareTag("score"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

}
