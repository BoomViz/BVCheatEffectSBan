using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace BVCheatEffectSBan
{
    public class CEBPlugin : RocketPlugin
    {
        public static CEBPlugin Instance;
        protected override void Load()
        {
            base.Load();
            Instance = this;
            var myMonoBehaviour = new GameObject("MyMonoBehaviour").AddComponent<MyMonoBehaviourClass>();
            DontDestroyOnLoad(myMonoBehaviour);
            Logger.Log("BVCheatEffectSBan plugin loaded successfully.");
        }

        public static bool Process(SteamPlayer player, string text)
        {
            bool flag = false;
            bool result = true;
            string a = text.Substring(0, 1);

            if ((a == "@" || a == "/") && player.isAdmin)
            {
                flag = true;
                result = false;
            }
            ChatManager.onCheckPermissions?.Invoke(player, text, ref flag, ref result);
            if (flag)
            {
                Commander.execute(player.playerID.steamID, text.Substring(1));
            }
            return (result);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "InvalidSyntax", "Неверный синтаксис. Правильный синтаксис: /cheatban <steamID64|playerName>" },
            { "PlayerNotFound", "Игрок не найден." },
            { "ApplyingEffectBan", "Применен эффект + бан к игроку {0} ({1})" },
            { "help_cheatban", "Применяет эффект, а затем выполняет команду /sban с перманентным баном за читерство."},
            { "syntax_cheatban", "/cheatban <steamID64|ИмяИгрока>"}
        };

        protected override void Unload()
        {
            base.Unload();
            Logger.Log("BVCheatEffectSBan plugin unloaded successfully.");
            Instance = null;
        }
    }
}