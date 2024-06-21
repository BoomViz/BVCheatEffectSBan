using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using UnityEngine;
using BVCheatEffectSBan.Translation;
using static SDG.Unturned.WeatherAsset;

namespace BVCheatEffectSBan.Command
{
    public class BVCheatEffectBanCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "cheatban";

        public string Help => ("help_cheatban").Translate();

        public string Syntax => ("syntax_cheatban").Translate();

        public List<string> Aliases => new List<string>() { "cban" };

        public List<string> Permissions => new List<string>() { "BV.СheaterEffectSban" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            ushort defaultEffectId = CEBPlugin.Config.DefaultEffect;
            uint defaultBanTime = CEBPlugin.Config.DefaultBanTime;
            ulong steamID;
            UnturnedPlayer player;

            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, ("InvalidSyntax").Translate());
                return;
            }

            string identifier = command[0];

            // Проверяем, является ли идентификатор числом (SteamID64)
            if (UInt64.TryParse(identifier, out steamID))
            {
                player = UnturnedPlayer.FromCSteamID(new Steamworks.CSteamID(steamID));
            }
            else
            {
                player = UnturnedPlayer.FromName(identifier);
            }

            if (player == null)
            {
                UnturnedChat.Say(caller, ("PlayerNotFound").Translate());
                return;
            }

            ushort effectId = command.Length > 1 && ushort.TryParse(command[1], out ushort parsedEffectId) ? parsedEffectId : defaultEffectId;
            float? banDelay = command.Length > 2 && float.TryParse(command[2], out float parsedBanDelay) ? parsedBanDelay : (command.Length == 1 ? defaultBanTime : 0);

            PlayerSpeedManager.ReducePlayerSpeed(player.Player);

            // Применяем эффект к игроку
            UnturnedChat.Say(caller, "ApplyingEffectBan".Translate(player.CharacterName, player.CSteamID, effectId));
            UnturnedChat.Say(caller, "BanDelay".Translate(banDelay));
            EffectManager.sendEffect(effectId, 50, player.Position);

            // Вызываем метод BanPlayer с возможным значением null для немедленного бана
            MyMonoBehaviourClass.Instance?.BanPlayer(player, banDelay);
        }
    }
}