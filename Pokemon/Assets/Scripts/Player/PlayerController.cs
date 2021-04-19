using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool moving;
    private Vector2 input;

    private Animator animator;

    public LayerMask collisionLayer;
    public LayerMask pokemonGrass;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {
                animator.SetFloat("MoveX", input.x);
                animator.SetFloat("MoveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (CheckCollision(targetPos))
                {
                    StartCoroutine(MovePlayer(targetPos));
                }
            }
        }
        animator.SetBool("MoveBool", moving);
    }

    IEnumerator MovePlayer (Vector3 targetPos)
    {
        moving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        moving = false;

        EncounterPokemon();
    }

    private void EncounterPokemon()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, pokemonGrass) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                Debug.Log("ENCOUNTER!");
            }
        }
    }

    private bool CheckCollision(Vector3 position)
    {
        if (Physics2D.OverlapCircle(position, 0.2f, collisionLayer) != null)
        {
            return false;
        }
        return true;
    }
}
