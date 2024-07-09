using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
public enum PlayerState
{
    [Description(" Walking state ")]
    walk,
    [Description(" Attack state ")]
    attack,
}

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    [SerializeField]
    private float moveSpeed = 10f;
    public PlayerState currentState;
    public Animator myAnim;

    public static PlayerController instance;
    public string areaTransitionName;

    public bool canMove = true;
    private Vector3 change;
    // if it was Serialized private 
    // it couldnot be accessed by the dialog manager as i was intended to

    // i want the player can be able to move fast 
    private bool isSpeedIncreased = false;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
       
    }

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(.5f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-.5f, -1f, 0f);
    }

    void Update()
    {
        if (canMove)
        {
            //HandleSpeedBoost();
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            change.Normalize();
            if (Input.GetButtonDown("attack") && currentState != PlayerState.attack )
            {
                StartCoroutine(AttackCoroutine());
            }
            if (currentState == PlayerState.walk)
            {
                UpdateAnimationAndMove();
            }
            
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }

    private IEnumerator AttackCoroutine()        //runs in parallel to something
    {
        myAnim.SetBool("attacking", true);      //setting animation bool to true
        currentState = PlayerState.attack;
        yield return null;                                    //waits 1 frame
        myAnim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);                 //waits .3 seconds 
        currentState = PlayerState.walk;
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero) 
        {
            MoveCharacter();
            myAnim.SetFloat("Horizontal", change.x);
            myAnim.SetFloat("Vertical", change.y);
            myAnim.SetBool("isMoving", true);
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
    }

    [SerializeField]
    private float speedMultiplier = 4f; 

    void MoveCharacter()
    {
        //change.Normalize();
        /* theRB.MovePosition(
             transform.position + (Time.deltaTime * moveSpeed * change)
            ); */

        Vector3 newPosition = transform.position + change * moveSpeed * Time.deltaTime;
        theRB.MovePosition(newPosition);

    }



    public void IncreasedSpeed()
    {
        isSpeedIncreased = !isSpeedIncreased;

        if (isSpeedIncreased)
        {
            PlayerController.instance.moveSpeed *= speedMultiplier;
        }
        else
        {
            
            PlayerController.instance.moveSpeed /= speedMultiplier;
        }
    }

    private void HandleSpeedBoost()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IncreasedSpeed();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IncreasedSpeed();
        }
    }
}
