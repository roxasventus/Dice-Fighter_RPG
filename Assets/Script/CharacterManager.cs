using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Status player1;
    public Status player2;

    [SerializeField]
    List<Status> characterList = new List<Status>();

    public GameObject player1_sprite;
    public GameObject player2_sprite;

    private Animator player1_animator;
    private Animator player2_animator;

    static public CharacterManager instance;

    private int player;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whichPlayer(int i ) { 
        player = i;
    }

    public void chooseCharacter(int characterIndex) {
        if (player == 1) { 
            player1 = characterList[characterIndex];
            player1_animator = player1_sprite.GetComponent<Animator>();
            player1_animator.runtimeAnimatorController = player1.animatorController;
        }
        else if (player == 2)
        {
            player2 = characterList[characterIndex];
            player2_animator = player2_sprite.GetComponent<Animator>();
            player2_animator.runtimeAnimatorController = player2.animatorController;
        }
    }
}
