using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.EventSystems;

public class PlayerMvmnt : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform dashGO;
    [SerializeField] private LayerMask dashLayerMask;


    //------------------------
    //Variables de déplacement :
    [SerializeField] private float vitesse;
    [SerializeField] private float dashAmount;
    [SerializeField] private float dashSize;
    private float horizontalMovement, verticalMovement;

    private Vector3 moveDir;//vecteur direction de déplacement
    private Vector3 aimDirection; //vecteur direction de "regard" (là ou pointe la souris !)

    //Dash :
    private bool isDashButtonDown;


    //KnockBack :
    private bool KnockBack;
    private float timerKnockback;
    private float timerKnockbackMax;
    private float timerStopMax;
    private float timerStop;





    private void Awake()
    {   
        //Init du dash
        isDashButtonDown = false;
    }

    void Update()
    {

        if(!KnockBack)
        {
            //Mvmnt
            horizontalMovement = Input.GetAxis("Horizontal");
            verticalMovement = Input.GetAxis("Vertical");
            moveDir = new Vector3(horizontalMovement, verticalMovement).normalized;

            //Dash
            if (Input.GetKeyDown("space"))
            {
                isDashButtonDown = true;
            }

            //Direction de visee
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            //vecteur allant du player a la souris
            aimDirection = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;

        } else
        {
            timerKnockback -= Time.deltaTime;
            timerStop -= Time.deltaTime;

            if (timerStop <= 0) rb.velocity = Vector3.zero;
            if (timerKnockback <= 0) KnockBack = false;
        }



       
    }

    private void FixedUpdate()
    {
        //Si le joueur n'est pas en situation de KnockBack.
        if (!KnockBack)
        {
            //Mouvement :
            MovePlayer();

            //Dash :
            if (isDashButtonDown)
            {
                DashPlayer();
            }
        }


    }

    private void MovePlayer()
    {
        rb.velocity = moveDir * vitesse;
    }

    private void DashPlayer()
    {
        Vector3 dashPosition = transform.position + aimDirection * dashAmount;

        //Raycast : pour ne pas pouvoir dash a travers les murs
        RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, aimDirection, dashAmount, dashLayerMask);
        if (raycastHit2d.collider != null) //si on touche qqchose
        {
            dashPosition = raycastHit2d.point; //alors l'arrivée du dash et l'endroit de collision
        }

        //Animation visuelle :
        Transform dashTransform = Instantiate(dashGO, transform.position, Quaternion.identity);
        dashTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(aimDirection));
        dashTransform.localScale = new Vector3((Vector3.Distance(transform.position, dashPosition)) * dashSize / 2f, dashSize, dashSize);


        rb.MovePosition(dashPosition);
        isDashButtonDown = false; //reset du dash
    }

    public void SetKnockback(Vector3 positionCollision, float timerKnockbackMax, float timerStopMax, float knockbackStrength)
    {

        //Timer pour le knockback :
        this.timerStopMax = timerStopMax;
        this.timerKnockbackMax = timerKnockbackMax;

        timerStop = timerStopMax;
        timerKnockback = timerKnockbackMax;

        //on stop le joueur et l'empeche de bouger : 
        KnockBack = true;
        rb.velocity = Vector3.zero;

        //On pousse le joueur :
        Vector3 direction = (positionCollision - transform.position).normalized;
        rb.AddForce(-direction * knockbackStrength);
    }
}
