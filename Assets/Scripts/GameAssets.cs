using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    public void Awake() {
        instance = this;
    }
    
    public Sprite snakeHeadUp;
    public Sprite snakeHeadDown;
    public Sprite snakeHeadLeft;
    public Sprite snakeHeadRight;
    public Sprite apple;
}
