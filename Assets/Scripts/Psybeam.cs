using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psybeam : Attack
{
    public Psybeam()
    {
        moveName = "Psybeam";
        accuracy = 100;  // 100% accuracy
        movePP = 20;     // Base PP
        critChance = 0;   // No critical hit chance by default
        damageType = AttackType.Special; // Special move
        power = 65;       // Psybeam's base power
        priority = 0;     // Normal priority
        type = Types.Psychic; // Psychic type
    }

    public enum StatusCondition
{
    None,
    Burned,
    Frozen,
    Paralyzed,
    Poisoned,
    Confused
}

public void ApplyStatusCondition(StatusCondition condition)
{
    // Handle status conditions here
    switch (condition)
    {
        case StatusCondition.Confused:
            // Logic for confusion (could prevent the Pokémon from attacking or cause it to hurt itself)
            // Set a flag or use a turn-based system to track confusion.
            break;
        // Handle other conditions (e.g., paralyzed, poisoned) similarly
        default:
            break;
    }
}


    // Override UseMove to implement Psybeam's behavior
    public override string UseMove(Pookiemon target)
    {
        // First, check if the move hits
        if (!AttemptMove())
        {
            return $"{user.pookiemonName} used {moveName}, but it missed!";
        }

        // Calculate damage (special move)
        int damageDealt = target.TakeSpecialDamage(user, this);

        // Check for confusion effect (10% chance)
        if (UnityEngine.Random.Range(0, 100) < 10)
        {
            // Apply confusion status if applicable
            target.ApplyStatusCondition(StatusCondition.Confused);
            return $"{user.pookiemonName} used {moveName}, dealing {damageDealt} damage and confusing the target!";
        }

        // Return a message indicating the damage dealt without confusion
        return $"{user.pookiemonName} used {moveName}, dealing {damageDealt} damage!";
    }

    // Override ExtraEffects (Psybeam has a chance to confuse)
    public override string ExtraEffects(Pookiemon target, int damageDealt)
    {
        return "";  // Extra effects handled in UseMove, no additional message needed
    }
}
