using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    [SerializeField]
    private Camera _followCamera;

    private Vector3 _playerVelocity;

    private bool coinBool;

    [SerializeField] private GameObject rewardText;

    [SerializeField] private GameObject collectRewardText;


    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _controller = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        Movement();
        RewardText();
    }

   

    void Movement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

        if (movementDirection != Vector3.zero) 
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    //Notify the player when he has enough point to collect a reward
    void RewardText()
    {
        if (Score.treesScore == 3)
        {
            collectRewardText.SetActive(true);
        }
    }
    
    //If the player has enough point gets the reward
    private void OnTriggerEnter(Collider other)
    {
        rewardText.SetActive(true);
        
        if (other.name.Equals("Drop Zone") && Score.treesScore == 3)
        {
            coinBool = true;
            Score.coinScore += 9;
        }
    }
    
    //Resets the player tree score
    private void OnTriggerExit(Collider other)
    {
        rewardText.SetActive(false);
        if (other.name.Equals("Drop Zone"))
        {
            coinBool = false;
            Score.treesScore = 0;
            CursorAim.FindObjectOfType<CursorAim>().enabled = true;
            collectRewardText.SetActive(false);
        }
    }

    void RewardCoin(bool coin)
    {
        coin = coinBool;
    }
}
