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
    [SerializeField] private Text P1Score;
    [SerializeField] private Text P2Score;
    [SerializeField] private Text P3Score;
    [SerializeField] private Text P4Score;

    private Animator animator;
    private bool isHopping;
    private int POneScore;
    private int PTwoScore;
    private int PThreeScore;
    private int PFourScore;
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
        //P1 Score Update
        if (Input.GetKeyDown(KeyCode.S))
        {
            POneScore = POneScore + 100;
        }
        else if((POneScore!=0) && (Input.GetKeyDown(KeyCode.W)))
        {
            POneScore = POneScore - 100;
        }
        //P2 Score update
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            POneScore = POneScore + 100;
        }
        else if ((POneScore != 0) && (Input.GetKeyDown(KeyCode.Keypad8)))
        {
            POneScore = POneScore - 100;
        }
        //P3 Score update
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            POneScore = POneScore + 100;
        }
        else if ((POneScore != 0) && (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            POneScore = POneScore - 100;
        }
        //P4 Score update
        else if (Input.GetKeyDown(KeyCode.K))
        {
            POneScore = POneScore + 100;
        }
        else if ((POneScore != 0) && (Input.GetKeyDown(KeyCode.I)))
        {
            POneScore = POneScore - 100;
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
        scoreText.text = "Score: " + (POneScore + PTwoScore + PThreeScore + PFourScore);
        

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
        if (CurrentSettings.PlayType) {
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

            if (Input.GetKeyDown(KeyCode.Keypad5) || (keycodeConversion == KeyCode.Keypad5) && !isHopping)
            {
                float zDifference = 0;
                if(transform.position.z % 1 != 0)
                {
                    zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
                }
                MoveCharacter(new Vector3(1, 0, zDifference));
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6) || (keycodeConversion == KeyCode.Keypad6) && !isHopping)
            {
                MoveCharacter(new Vector3(0, 0, 1));
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4) || (keycodeConversion == KeyCode.Keypad4) && !isHopping)
            {
                MoveCharacter(new Vector3(0, 0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.Keypad8) || (keycodeConversion == KeyCode.Keypad8) && !isHopping)
            {
                float zDifference = 0;
                if (transform.position.z % 1 != 0)
                {
                    zDifference = Mathf.Round(transform.position.z + 1) - transform.position.z;
                }
                MoveCharacter(new Vector3(-1, 0, zDifference));
            }
        }

        if(this.transform.position.x < -1) {
            UndoLastMove();
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
        this.POneScore -= 100;     
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
