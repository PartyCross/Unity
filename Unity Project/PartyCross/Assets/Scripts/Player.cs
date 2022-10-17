//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public static event Action OnPlayerDeath;

    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;

    private Animator animator;
    private bool isHopping;
    private int score;
    private KeyCode keycodeConversion;
    private AudioSource stepSound;
    private Vector3 prevMove;

    private void Start()
    {
        animator = GetComponent<Animator>();
        stepSound = this.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            score = score + 100;
        }
        else if((score!=0) && (Input.GetKeyDown(KeyCode.W)))
        {
            score = score - 100;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Plank>() != null)
        {
            if (collision.collider.GetComponent<Plank>().isLog)
            {
                transform.parent = collision.collider.transform;

                //OnPlayerDeath?.Invoke();
            }
        }
        else
        {
            transform.parent = null;
        }

        if(collision.gameObject.name.Substring(0,4) == "Bush" || collision.gameObject.name.Substring(0,4) == "Tree") {
            this.UndoLastMove();
        }
    }

    private void Update()
    {
        if(this.transform.position.y < -5) {
            this.GetComponent<PlayerHealth>().decreaseHealth(100000);
        }
        scoreText.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.S) || (keycodeConversion == KeyCode.S) && !isHopping)
        {
            float zDifference = 0;
            if(transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        }
        else if (Input.GetKeyDown(KeyCode.D) || (keycodeConversion == KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A) || (keycodeConversion == KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.W) || (keycodeConversion == KeyCode.W) && !isHopping)
        {
            float zDifference = 0;
            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
            }
            MoveCharacter(new Vector3(-1, 0, zDifference));
        }

        //MULTIPLAYER
        if(CurrentSettings.PlayType) {
            if (Input.GetKeyDown(KeyCode.K) || (keycodeConversion == KeyCode.K) && !isHopping)
            {
                float zDifference = 0;
                if(transform.position.z % 1 != 0)
                {
                    zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
                }
                MoveCharacter(new Vector3(1, 0, zDifference));
            }
            else if (Input.GetKeyDown(KeyCode.L) || (keycodeConversion == KeyCode.L) && !isHopping)
            {
                MoveCharacter(new Vector3(0, 0, 1));
            }
            else if (Input.GetKeyDown(KeyCode.J) || (keycodeConversion == KeyCode.J) && !isHopping)
            {
                MoveCharacter(new Vector3(0, 0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.I) || (keycodeConversion == KeyCode.I) && !isHopping)
            {
                float zDifference = 0;
                if (transform.position.z % 1 != 0)
                {
                    zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
                }
                MoveCharacter(new Vector3(-1, 0, zDifference));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || (keycodeConversion == KeyCode.DownArrow) && !isHopping)
            {
                float zDifference = 0;
                if(transform.position.z % 1 != 0)
                {
                    zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
                }
                MoveCharacter(new Vector3(1, 0, zDifference));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || (keycodeConversion == KeyCode.RightArrow) && !isHopping)
            {
                MoveCharacter(new Vector3(0, 0, 1));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || (keycodeConversion == KeyCode.LeftArrow) && !isHopping)
            {
                MoveCharacter(new Vector3(0, 0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || (keycodeConversion == KeyCode.UpArrow) && !isHopping)
            {
                float zDifference = 0;
                if (transform.position.z % 1 != 0)
                {
                    zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
                }
                MoveCharacter(new Vector3(-1, 0, zDifference));
            }
        }


        FixedUpdate();
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        this.stepSound.Play();
        isHopping = true;
        transform.position = (transform.position + difference);
        this.prevMove = difference;
        terrainGenerator.SpawnTerrain(false, transform.position);
    }

    private void UndoLastMove() {
        transform.position = (transform.position - this.prevMove);
        terrainGenerator.SpawnTerrain(false, transform.position);
        this.score -= 100;     
    }

    public void FinishHop()
    {
        isHopping = false;
    }

    public void UpTouch()
    {
        keycodeConversion = KeyCode.W;
        Update();
    }

    public void DownTouch()
    {
        keycodeConversion = KeyCode.S;
        Update();
    }

    public void LeftTouch()
    {
        keycodeConversion = KeyCode.A;
        Update();
    }

    public void RightTouch()
    {
        keycodeConversion = KeyCode.D;
        Update();
    }
}
