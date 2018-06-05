using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : Character {

    public CharacterController controller;

    public float MoveSpeed = 0.2f;

    public SpriteHolder spriteHolder;
    public SpriteRenderer spriteRenderer;

    private Vector2 userInput = -Vector2.one;
    private bool userInputStarted = false;
    private int joystickIsAtIndex = -1;
    public Texture2D JoysticBackground;
    public Texture2D JoystickFront;
    private Sprite joystic;
    private float joyStickX = 0;
    private float joyStickY = 0;

    public Texture2D collectableEmpty;
    public Texture2D collectableBackground;

    //Floats to hold the input move speed
    private float xSpeed = 0;
    private float ySpeed = 0;

    //private List<Item> collectedItems;
    public ItemHolder itemHolder;

    public Player()
    {
        
    }
    
	void Start () {
        //string a = ApplicationHttp.Post();

    }
    void OnGUI()
    {
        //Collectables
        itemHolder.Draw();

        //Joystick
        if (userInputStarted)
        {
            int joystickSize = Screen.width / 6;

            int posX = (int)userInput.x - (joystickSize / 2);
            int posY = Screen.height - (int)userInput.y - (joystickSize / 2);

            Rect position = new Rect(posX, posY, joystickSize, joystickSize);
            GUI.DrawTexture(position, JoysticBackground);

            int posXMove = (int)(joyStickX * 90);
            int posYMove = (int)(joyStickY * 90);

            Rect position2 = new Rect(posX + (joystickSize / 4) + posXMove, posY + (joystickSize / 4) - posYMove, joystickSize / 2, joystickSize / 2);
            GUI.DrawTexture(position2, JoystickFront);
        }
    }
	
	void Update () {

        if (spriteHolder == null) return;
        if (userInputStarted) itemHolder.CloseCollectionsBox();

        move();

	}
    void move()
    {
        //float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");

        bool joystickIsAlreadyTouched = false;

        xSpeed += Input.GetAxis("Horizontal") / 3;
        ySpeed += Input.GetAxis("Vertical") / 3;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            if (touch.position.x < (Screen.width / 2) - (Screen.width / 8))
            {
                if (!joystickIsAlreadyTouched)
                {
                    joystickIsAlreadyTouched = true;

                    if (touch.phase == TouchPhase.Began)
                    {
                        userInput = touch.position;
                        userInputStarted = true;
                        joystickIsAtIndex = i;

                        //joystic = Sprite.Create(JoysticBackground, new Rect(0.0f, 0.0f, JoysticBackground.width, JoysticBackground.height), new Vector2(0.5f, 0.5f), 100.0f);
                    }
                }
            }
            else
            {

            }

            if (userInputStarted && i == joystickIsAtIndex)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 currentUserInput = touch.position;
                    Debug.Log(currentUserInput.x);

                    Vector2 posss = transform.position;

                    xSpeed = (touch.position.x - userInput.x) / 175;
                    ySpeed = (touch.position.y - userInput.y) / 175;
                    transform.position = posss;

                    if (xSpeed >= 1) xSpeed = 1;
                    else if (xSpeed <= -1) xSpeed = -1;
                    if (ySpeed >= 1) ySpeed = 1;
                    else if (ySpeed <= -1) ySpeed = -1;

                    joyStickX = xSpeed;
                    joyStickY = ySpeed;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    userInputStarted = false;
                    joystickIsAtIndex = -1;
                    xSpeed = 0;
                    ySpeed = 0;
                }
            }
        }

        float inputX = xSpeed;
        float inputY = ySpeed;

        //float xSpeed = inputX;
        //float ySpeed = inputY;

        if (Mathf.Abs(inputX) > Mathf.Abs(inputY))
        {
            inputY = 0;
            //ySpeed /= 1.5f;
            ySpeed = 0;
        }
        else
        {
            inputX = 0;
            //xSpeed /= 1.5f;
            xSpeed = 0;
        }

        //if(xSpeed != 0 && ySpeed != 0)
        //{
            if (inputX > 0) // Numbers are the same as the numpad control
                spriteHolder.SetDirection(6);
            else if (inputX < 0)
                spriteHolder.SetDirection(4);
            else if (inputY > 0)
                spriteHolder.SetDirection(8);
            else if (inputY < 0)
                spriteHolder.SetDirection(2);
            else
                spriteHolder.SetDirection(5);
        //}

        setSprite();

        //Debug.Log(spriteHolder.GetDirectionName()); // It works, the direction are right // Debugs are deleted becouse it slows down the program

        //StartCoroutine(Move(inputX, inputY));

        /*Vector2 pos = transform.position;
        pos.x += xSpeed * Time.deltaTime * 5;
        pos.y += ySpeed * Time.deltaTime * 5;

        transform.position = pos;*/

        Vector3 moveDirection = Vector3.zero;

        moveDirection = new Vector3(xSpeed * MoveSpeed, ySpeed * MoveSpeed, 0);
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * (Time.deltaTime / 1.5f));

    }
    private void setSprite()
    {
        if (spriteRenderer == null) return;
        spriteRenderer.sprite = spriteHolder.GetSprite();
    }
    public void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log("fbgfb");
    }

    public void AddCollectingItem(Item item)
    {
        itemHolder.AddItem(item);
    }

    public void GotString(string s)
    {
        Debug.Log(s);
    }
    private void AskData()
    {
        string url = "http://tahayasin.be/api/testunity.php";

        StartCoroutine(GetData(url));
    }
    private IEnumerator<string> GetData(string url)
    {
        using (WWW www = new WWW(url))
        {
            yield return www.text;
            GotData(www.text);
        }
    }
    private void GotData(string s)
    {
        Debug.Log("Http ----->");
        Debug.Log(s);
        Debug.Log("<-----");
    }
}