using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{

    [SerializeField] private GameObject _applePrefab;
    private GameObject _appleInstance;
    [SerializeField] public static int points;
    public static bool CreateNewSnakeBody;
    
    void Awake() {
        points = 0;
        CreateNewSnakeBody = false;
    }

    // Start is called before the first frame update

    void Start()
    {
        createApple();
    }

    // Update is called once per frame
    void Update()
    {
        if(_appleInstance != null) {
            if (GameObject.Find("SnakeHead").transform.position == _appleInstance.transform.position) {
                Destroy(_appleInstance);
                createApple();
                points++;
                CreateNewSnakeBody = true;

            }
        }
    }

    void createApple() {
        Vector3 applePosition = new Vector3(Random.Range(0, 16), Random.Range(0, 16), 3);
        Vector3 appleRotation = new Vector3(0, 0, 0);
        _appleInstance = Instantiate (_applePrefab, applePosition, Quaternion.Euler(appleRotation), GameObject.Find("Apples").transform);
        
    }
}
