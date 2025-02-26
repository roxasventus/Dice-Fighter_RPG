using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene() {
        if (SceneName == "BattleScene")
        {
            if (CharacterManager.instance.player1 != null && CharacterManager.instance.player2 != null)
            {
                SceneManager.LoadScene(SceneName);
            }
            else {
                Debug.Log("캐릭터를 선택하십시오.");
            }
        }
        else 
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
