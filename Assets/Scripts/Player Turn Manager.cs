using TMPro;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    public GameObject player1_stone;
    public GameObject player2_stone;

    public TextMeshProUGUI player1_score_text;
    public TextMeshProUGUI player2_score_text;
    private Player player1 = new Player(1);
    private Player player2 = new Player(2);


    private GameObject scoring_target;

    
    [SerializeField] private int currentPlayerIndex = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoring_target = GameObject.Find("Scoring Target");
    }

    // Update is called once per frame
    void Update()
    {
        player1_score_text.text = "Player 1 Score: " + player1.score;
        player2_score_text.text = "Player 2 Score: " + player2.score;
    }
    public void EndTurn()
    {
        UpdatePlayerScores();
        if(currentPlayerIndex == 1 && player1.stones_remaining > 1) // > 1 since player starts with stone already on field
        {
            player1.stones_remaining--;
            Instantiate(player2_stone, new Vector3(0,1,0), Quaternion.identity);
            
            currentPlayerIndex = 2;
        }
        else if(currentPlayerIndex == 2 && player2.stones_remaining > 0)
        {
            player2.stones_remaining--;
            Instantiate(player1_stone, new Vector3(0,1,0), Quaternion.identity);
            currentPlayerIndex = 1;
        }
        else
        {
            // end of game logic here 
        }
    }
    public void UpdatePlayerScores()
    {
        player1.score = scoring_target.GetComponent<TargetScoring>().Calculate_Score(player1.player_number);
        player2.score = scoring_target.GetComponent<TargetScoring>().Calculate_Score(player2.player_number);
        Debug.Log("Player 1 Score: " + player1.score);
        Debug.Log("Player 2 Score: " + player2.score);
    }
}
