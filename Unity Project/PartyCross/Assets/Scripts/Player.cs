using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;

    private Animator animator;
    private bool isHopping;
    private int score;
    private KeyCode keycodeConversion;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.S)))
        {
            score = score + 100;
        }
        else if(((score!=0) && (Input.GetKeyDown(KeyCode.W))) || (keycodeConversion == KeyCode.W))
        {
            score = score - 100;
        }
    }

    private void Update()
    {
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
        FixedUpdate();
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false, transform.position);
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
