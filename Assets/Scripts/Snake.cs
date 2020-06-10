using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _snakePosition;
    private string _currentDirection = "none";
    private float _gridMoveTimer;
    private float _gridMoveTimerMax;
    public static List<Vector3> SnakeHeadPastPositions;


    private void Awake() {
        SnakeHeadPastPositions = new List<Vector3>();
        GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeHeadUp;
        _snakePosition = new Vector2(transform.position.x, transform.position.y);
        _gridMoveTimerMax = 0.5f;
        _gridMoveTimer = 0f;
    }

    private void Start() {
        
    }
    
    private void Update() {
        if (Input.GetKeyDown("w")) {
            _currentDirection = "up";
        }
        else if (Input.GetKeyDown("s")) {
            _currentDirection = "down";
        }
        else if (Input.GetKeyDown("a")) {
            _currentDirection = "left";
        }
        else if (Input.GetKeyDown("d")) {
            _currentDirection = "right";
        }
        else {
        }
        _gridMoveTimer += 4*Time.deltaTime;
        if (_gridMoveTimer >= _gridMoveTimerMax) {
            move();
            Vector3 newSnakePosition = new Vector3(_snakePosition.x, _snakePosition.y, transform.position.z);
            _gridMoveTimer = 0f;
            transform.position = newSnakePosition;
            Debug.Log(SnakeHeadPastPositions.Count);
            if (_currentDirection != "none") {
                SnakeHeadPastPositions.Insert(0, newSnakePosition);
            }
    
        }

    }

    private void move() {
        switch(_currentDirection) {
            case "up":
                _snakePosition.y += 1;
                GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeHeadUp;                
                break;
            case "down":
                _snakePosition.y -= 1;
                GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeHeadDown;             
                break;
            case "left":
                _snakePosition.x -= 1;
                GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeHeadLeft;              
                break;
            case "right":
                _snakePosition.x += 1;
                GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeHeadRight;
                break;
            case "none":
                break;
        }
    }


}
