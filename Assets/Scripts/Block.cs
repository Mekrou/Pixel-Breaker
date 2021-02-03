using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BlockState
{
    DEFAULT,
    DAMAGED,
    BROKEN
};

public class Block : MonoBehaviour
{
    [SerializeField] Sprite damaged;

    private BlockState currentState = BlockState.DEFAULT;
    private static int blocksBroken = 0;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("CoreGame_Diamond") && currentState != BlockState.DAMAGED)
        {
            currentState = BlockState.DAMAGED;
            return;
        } 
        
        if (currentState == BlockState.DAMAGED)
        {
            currentState = BlockState.BROKEN;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blocksBroken = 0;
        Debug.Log(blocksBroken);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case BlockState.DEFAULT:
                break;
            case BlockState.DAMAGED:
                gameObject.GetComponent<SpriteRenderer>().sprite = damaged;
                break;
            case BlockState.BROKEN:
                gameObject.SetActive(false);
                blocksBroken += 1;
                
                break;
        }

        if (blocksBroken == 24)
        {
            SceneManager.LoadScene(0);
        }
    }
}
