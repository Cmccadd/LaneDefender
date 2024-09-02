using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public PlayerInput myPlayerInput;
    private InputAction restart;
    private InputAction quit;
    // Start is called before the first frame update
    void Start()
    {
        myPlayerInput.currentActionMap.Enable();
        restart = myPlayerInput.currentActionMap.FindAction("Restart");
        quit = myPlayerInput.currentActionMap.FindAction("Quit");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
