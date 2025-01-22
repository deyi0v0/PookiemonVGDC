using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTail : Attack
{
    public DragonTail()
    {
        moveName = "Dragon Tail";
        accuracy = 90;  // 90% accuracy
        movePP = 10;     // Base PP
        critChance = 0;   // No critical hit chance by default
        damageType = AttackType.Physical; // Physical move
        power = 60;       // Dragon Tail's base power
        priority = -6;    // Low priority (-6)
        type = Types.Dragon; // Dragon type
    }

    // Override UseMove to implement Dragon Tail's behavior
    public override string UseMove(Pookiemon target)
    {
        // First, check if the move hits
        if (!AttemptMove())
        {
            return $"{user.pookiemonName} used {moveName}, but it missed!";
        }

        // Calculate damage (physical move)
        int damageDealt = target.TakePhysicalDamage(user, this);

        // After damage, notify the system that the opponent should switch
        NotifySwitchOut(target);

        // Return a message indicating the damage dealt and that a switch-out should happen
        return $"{user.pookiemonName} used {moveName}, dealing {damageDealt} damage! {target.pookiemonName} is about to switch out!";
    }

    // This method simulates notifying the system about the switch-out effe
