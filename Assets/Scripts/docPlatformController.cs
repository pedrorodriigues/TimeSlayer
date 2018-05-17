using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{

    // Crie as variáveis globais
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false; 
    public float moveForce = 365f; // força no movimento
    public float maxSpeed = 5f; //velocidade máxima que o hero irá atingir
    public float jumpForce = 1000f; //força do lupo, define a altura
    public Transform groundCheck; // verifica se o hero está enconstando no chão


    private bool grounded = false;
    private Animator anim; // para a animação dos sprites
    private Rigidbody2D rb2d; // corpo rígido do hero


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>(); // obtém a animação do hero
        rb2d = GetComponent<Rigidbody2D>(); // obtém o corpo rígido do hero
    }

    // Update is called once per frame
    void Update()
    {
        // verifica a posição do hero em relação ao chão. A camada Ground será definida na plataforma.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded) // só pula se estiver enconstando no chão.
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h)); // define a velocidade da animação do hero. valor absoluto (sem sinal)

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);
        // valor absoluto, funciona tanto para direita quanto para esquerda
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        // Movendo para direita mas o sprite está olhando para a esquerda.
        if (h > 0 && !facingRight)
            Flip();
        // Movendo para esquerda mas o sprite está olhando para a direita.
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump"); // set animação do pulo para o hero
            rb2d.AddForce(new Vector2(0f, jumpForce)); // adiciona a força do pulo em Y
            jump = false; // Sem pulo duplo.

        }
    }


    void Flip() // garante que o hero sempre estará olhando para o lado que ele estiver andando.
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}