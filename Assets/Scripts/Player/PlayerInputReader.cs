using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private GameInputs _input;
    [SerializeField] private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _input = new GameInputs();
        _input.Player.Enable();
        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Climb.performed += Climb_performed;
    }

    private void Climb_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _player.ClimbLedge();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _player.Jump();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _input.Player.Movement.ReadValue<Vector2>();
        Vector3 direction = new Vector3(0, 0, input.x);
        

        _player.Movement(direction);
        //get player inputs in vector 2
        //make new vector 3 with inputs
        //call player movement with input parameter
    }
}
