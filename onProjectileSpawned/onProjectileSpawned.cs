using uScript.API.Attributes;
using SDG.Unturned;
using uScript.Core;
using uScript.Module.Main.Classes;
using System.Reflection;
using uScript.Unturned;
using UnityEngine;

namespace onProjectileSpawned
{
    [ScriptEvent("onProjectileSpawned", "player")]
    public class OnPlayerShoot : ScriptEvent
    {
        public override EventInfo EventHook(out object instance)
        {
            instance = null;
            return typeof(UseableGun).GetEvent("onProjectileSpawned", BindingFlags.Public | BindingFlags.Static);
        }
        [ScriptEventSubscription]
        public void onProjectileSpawned(UseableGun sender, GameObject projectile)
        {
            var player = sender.player.channel.owner;
            var args = new ExpressionValue[]
            {
                ExpressionValue.CreateObject(new PlayerClass(player.player)),
            };
            RunEvent(this, args);
        }
    }
}