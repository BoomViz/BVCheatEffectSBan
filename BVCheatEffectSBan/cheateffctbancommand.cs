using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using UnityEngine;
using BVCheatEffectSBan.Translation;

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
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, ("InvalidSyntax").Translate());
                return;
            }

            string identifier = command[0];
            ulong steamID;
            UnturnedPlayer player;

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

            // Применяем эффект к игроку
            UnturnedChat.Say(caller, "ApplyingEffectBan".Translate(player.CharacterName, player.CSteamID));
            EffectManager.sendEffect(167, 35, player.Position);

            // Вызываем метод ExecuteSban для бана игрока
            ExecuteSban(player);
        }

        private void ExecuteSban(UnturnedPlayer player)
        {
            if (MyMonoBehaviourClass.Instance != null)
            {
                MyMonoBehaviourClass.Instance.BanPlayer(player);
            }
            else
            {
                // Обработка ошибки, если экземпляр не найден
                Debug.LogError("MyMonoBehaviourClass instance not found.");
            }
        }
    }
}