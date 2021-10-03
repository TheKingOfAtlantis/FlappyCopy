using System;
using System.Collections;

using UnityEngine;
public class GameController : MonoBehaviour
{

    static public GameController Instance;
    // Use this for initialization

    void Awake()
    {
        // If the game controller doesn't exist yet create it
        // If it does and this isn't the same as the instance then destroy this 
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    void Start()
    {
    }
}
