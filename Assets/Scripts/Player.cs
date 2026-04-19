using UnityEngine;

public class Player : MonoBehaviour
{
    public int player_number;
    public int score;
    public int stones_remaining;

    public Player(int current_player_number)
    {
        this.player_number =current_player_number;
        this.score = 0;
        this.stones_remaining = 4;
    }
}
