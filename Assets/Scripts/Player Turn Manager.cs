using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    private int playerRounds = 4;
    [SerializeField] private int currentPlayerIndex = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRounds = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndTurn()
    {
        if(currentPlayerIndex == 1)
        {
            Instantiate(player2, new Vector3(0,1,0), Quaternion.identity);
            currentPlayerIndex = 2;
        }
        else
        {
            Instantiate(player1, new Vector3(0,1,0), Quaternion.identity);
            currentPlayerIndex = 1;
        }
    }
}
