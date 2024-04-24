using System;
using System.Linq;

public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }
    private static Random rng = new Random(DateTime.Now.Millisecond);

    DndCharacter()
    {
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = 10 + Modifier(Constitution);
    }
    public static int Modifier(int score)
    {
        return Convert.ToInt32(Math.Floor(((float)score - 10) / 2));
    }

    public static int Ability() 
    {
        int[] diceRolls = {
            rng.Next(1,7),
            rng.Next(1,7),
            rng.Next(1,7),
            rng.Next(1,7)
        };
        int lowestRollIndex = 0;
        for (int i = 0, lowestRoll = diceRolls.Min() ; i < diceRolls.Length; i++)
            lowestRollIndex = diceRolls[i] == lowestRoll ? i : lowestRollIndex;
        diceRolls[lowestRollIndex] = 0;
        return diceRolls.Sum();
    }

    public static DndCharacter Generate()
    {
        return new DndCharacter();
    }
}
