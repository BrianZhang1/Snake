using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{

    [SerializeField] private GameObject _snakeBodyPrefab;
    private List<GameObject> snakeBodyList;

    void Awake() {
        snakeBodyList = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < snakeBodyList.Count; i++) {
            snakeBodyList[i].transform.position = Snake.SnakeHeadPastPositions[i + 1];
        }

        if (AppleScript.CreateNewSnakeBody) {
            createSnakeBody();
            AppleScript.CreateNewSnakeBody = false;
        }

    }

    private void createSnakeBody() {
        Vector3 snakeBodyPosition = Snake.SnakeHeadPastPositions[snakeBodyList.Count];
        Vector3 snakeBodyRotation = new Vector3(0, 0, 0);
        GameObject snakeBodyInstance = Instantiate (_snakeBodyPrefab, snakeBodyPosition, Quaternion.Euler(snakeBodyRotation), transform);
        snakeBodyList.Add(snakeBodyInstance);
    }
}
