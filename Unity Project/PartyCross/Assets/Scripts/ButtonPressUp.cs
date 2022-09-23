using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressUp : MonoBehaviour
{
    [SerializeField] GameObject characterModel;
    Player player;

    public void update()
    {
        characterModel.GetComponent<Player>().UpTouch();
    }
}
