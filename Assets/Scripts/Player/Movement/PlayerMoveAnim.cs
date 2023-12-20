using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnim : MonoBehaviour
{

    [SerializeField] List<GameObject> animalForms;
    [SerializeField] int manaCostAbility = 10;
    private GameObject currentAnimal;

    private CharacterController characterController;
    Animator animator;
    private SFXManager sfxManager;
    private PlayerController player;
    private float horizontalInput;
    private float verticalInput;
    private float pushedTime = 0f;
    private float timeToRun = 2f;

    // Start is called before the first frame update
    void Start()
    {

        currentAnimal = animalForms[FindAnimal()];
        animator = currentAnimal.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        sfxManager = SFXManager.Instance;
        player = this.GetComponent<PlayerController>();
    }

    private bool IsCurrentAnimal(GameObject animal)
    {
        return animal.activeSelf;
    }

    private int FindAnimal()
    {
        int index = -1;

        foreach (GameObject animal in animalForms)
        {
            if (IsCurrentAnimal(animal))
            {
                index = animalForms.IndexOf(animal);
            }
        }

        return index;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCurrentAnimal(currentAnimal))
        {
            currentAnimal = animalForms[FindAnimal()];
            animator = currentAnimal.GetComponent<Animator>();
        }
        bool runningKey = Input.GetKey(KeyCode.LeftShift);
        bool skillKey = Input.GetKeyDown(KeyCode.Space);

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //correr a los 4 seg de mantener pulsado
        if (verticalInput > 0)
        {
            pushedTime += Time.deltaTime;

            if (pushedTime >= timeToRun)
            {
                animator.SetFloat("verticalSpeed", verticalInput, 0.05f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("verticalSpeed", verticalInput / 2, 0.05f, Time.deltaTime);
            }
        }
        else
        {
            animator.SetFloat("verticalSpeed", verticalInput / 2, 0.05f, Time.deltaTime);
            pushedTime = 0;
        }

        //correr con shift
        //if (runningKey && verticalInput > 0)
        //{
        //    animator.SetFloat("verticalSpeed", verticalInput, 0.05f, Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetFloat("verticalSpeed", verticalInput / 2, 0.05f, Time.deltaTime);
        //}


        animator.SetFloat("horizontalSpeed", horizontalInput/2, 0.05f, Time.deltaTime);
        
        
        //usar habilidad - esto activa la animacion
        if (skillKey && characterController.isGrounded && player.currentMana >= manaCostAbility)
        {
            player.RegenMana(-manaCostAbility);
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            //si no está saltando, usa habilidad
            if (!stateInfo.IsName("Jump"))
            {
                
                animator.SetTrigger("useSkill");
                if (currentAnimal.name == "Deer Female")
                {
                    onAnimation onAnimation = currentAnimal.GetComponent<onAnimation>();
                    onAnimation.updateYSpeed();
                }
            }
            
        }

    }
}
