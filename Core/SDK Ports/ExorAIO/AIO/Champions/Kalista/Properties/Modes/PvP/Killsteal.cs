
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Utility;

#pragma warning disable 1587

namespace ExorAIO.Champions.Kalista
{
    using System;
    using System.Linq;

    using ExorAIO.Utilities;


    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Logics
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Called when the game updates itself.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void Killsteal(EventArgs args)
        {
            /// <summary>
            ///     The KillSteal Q Logic.
            /// </summary>
            if (Vars.Q.IsReady() && Vars.Menu["spells"]["q"]["killsteal"].GetValue<MenuBool>().Enabled)
            {
                foreach (var target in
                    GameObjects.EnemyHeroes.Where(
                        t =>
                        !Invulnerable.Check(t) && !Kalista.IsPerfectRendTarget(t) && t.IsValidTarget(Vars.Q.Range)
                        && !t.IsValidTarget(GameObjects.Player.GetRealAutoAttackRange())
                        && Vars.GetRealHealth(t) < (float)GameObjects.Player.GetSpellDamage(t, SpellSlot.Q)))
                {
                    if (!Vars.Q.GetPrediction(target).CollisionObjects.Any()
                        || Vars.Q.GetPrediction(target)
                               .CollisionObjects.Count(
                                   c =>
                                   Targets.Minions.Contains(c)
                                   && c.Health < (float)GameObjects.Player.GetSpellDamage(c, SpellSlot.Q))
                        == Vars.Q.GetPrediction(target).CollisionObjects.Count(c => Targets.Minions.Contains(c)))
                    {
                        Vars.Q.Cast(Vars.Q.GetPrediction(target).UnitPosition);
                    }
                }
            }

            /// <summary>
            ///     The KillSteal E Logic.
            /// </summary>
            if (Vars.E.IsReady() && Vars.Menu["spells"]["e"]["killsteal"].GetValue<MenuBool>().Enabled)
            {
                if (
                    GameObjects.EnemyHeroes.Any(
                        t =>
                        Kalista.IsPerfectRendTarget(t)
                        && Vars.GetRealHealth(t)
                        < (float)GameObjects.Player.GetSpellDamage(t, SpellSlot.E)
                        + (float)GameObjects.Player.GetSpellDamage(t, SpellSlot.E)))
                {
                    Vars.E.Cast();
                }
            }
        }

        #endregion
    }
}