using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lick : Move
{
    public Lick()
    {
        moveName = "Lick";
        accuracy = 100;  // Lick always has 100% accuracy
        movePP = 30;     // Base PP
        priority = 0;     // Normal priority
        type = Types.Ghost; // Ghost type
    }

    // Override UseMove to implement Lick's behavior
    public override string UseMove(Pookiemon target)
    {
        // First check if the move hits
        if (!AttemptMove())
        {
            return $"{user.name}'s {moveName} missed!";
        }

        // Calculate the damage (physical move)
        int damageDealt = target.TakePhysicalDamage(user, this);

        // Apply additional effects (like paralysis)
        return ExtraEffects(target, damageDealt);
    }

    // Additional effects for Lick (e.g., paralysis chance)
    public override string ExtraEffects(Pookiemon target, int damageDealt)
    {
        // Check if the target is susceptible to paralysis
        if (ShouldParalyze(target))
        {
            target.ApplyStatusEffect(StatusEffect.Paralyzed);
            return $"{user.name} used {moveName}, dealing {damageDealt} damage, and {target.name} was paralyzed!";
        }
        else
        {
            return $"{user.name} used {moveName}, dealing {damageDealt} damage!";
        }
    }

    // Check if Lick should paralyze the target (30% chance)
    private bool ShouldParalyze(Pookiemon target)
    {
        // Electric types, Limber ability, or Substitute cannot be paralyzed
        if (target.HasType(Types.Electric) || target.HasAbility("Limber") || target.IsBehindSubstitute())
        {
            return false;
        }

        // 30% chance to paralyze
        return UnityEngine.Random.Range(0f, 1f) < 0.30f;
    }
}
