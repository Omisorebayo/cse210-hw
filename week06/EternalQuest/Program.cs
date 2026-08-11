public class Program
{
    public static void Main(string[] args)
    {
        // Creativity / Exceeding Requirements:
        // In addition to the required goal tracking features, this program
        // includes a leveling system and achievement ranks. The player
        // automatically levels up as their score increases and receives
        // different ranks such as Quest Beginner, Growing Disciple,
        // Faithful Adventurer, Quest Master, and Eternal Champion.
        //
        // The program also displays a special message whenever the player
        // levels up, providing additional motivation and gamification.

        GoalManager manager = new GoalManager();

        manager.Start();
    }
}