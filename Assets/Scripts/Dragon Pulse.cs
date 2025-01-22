using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPulse : Attack
{
    public DragonPulse()
    {
        moveName = "Dragon Pulse";
        accuracy = 100;  // 100% accuracy
        movePP = 10;     // Base PP
        critChance = 0;   // No critical hit chance
        damageType = AttackType.Special; // Special move
        power = 85;       // Dragon Pulse's base power
        priority = 0;     // Normal priority
        type = Types.Dragon; // Dragon type
    }

    // Override UseMove to implement Dragon Pulse's behavior
    public override string UseMove(Pookiemon target)
    {
        // First, check if the move hits
        if (!AttemptMove())
        {
            return $"{user.pookiemonName} used {moveName}, but it missed!";
        }

        // Calculate damage (special move)
        int damageDealt = target.TakeSpecialDamage(user, this);

        // Return a message indicating the damage dealt
        return $"{user.pookiemonName} used {moveName}, dealing {damageDealt} damage!";
    }

    // Override ExtraEffects (Dragon Pulse has no additional effects)
    public override string ExtraEffects(Pookiemon target, int damageDealt)
    {
        return "";  // No extra effects
    }
}
