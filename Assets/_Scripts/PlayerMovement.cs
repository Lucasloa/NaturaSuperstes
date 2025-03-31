using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int PlayerHealth = 3;
    private int currentHealth;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private bool facingLeft = false;

    private void Start()
    {
        currentHealth = PlayerHealth;
    }
    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = false;
            FacingLeft = false;
        }
        else
        {
            mySpriteRenderer.flipX = true;
            FacingLeft = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
