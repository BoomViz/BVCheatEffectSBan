using BVCheatEffectSBan;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned.Player;
using System.Collections;
using UnityEngine;

public class MyMonoBehaviourClass : MonoBehaviour
{
    public static MyMonoBehaviourClass Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("MyMonoBehaviourClass instance was created.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Duplicate instance of MyMonoBehaviourClass was destroyed.");
        }
    }

    public void BanPlayer(UnturnedPlayer player, float? delay)
    {
        if (delay.HasValue)
        {
            StartCoroutine(BanAfterDelay(player, delay.Value));
        }
        else
        {
            ExecuteBan(player);
        }
    }

    private IEnumerator BanAfterDelay(UnturnedPlayer player, float delay)
    {
        yield return new WaitForSeconds(delay);
        ExecuteBan(player);
    }

    private void ExecuteBan(UnturnedPlayer player)
    {
        PlayerSpeedManager.RestorePlayerSpeed(player.Player);
        string command = CEBPlugin.Config.BanCommand;
        R.Commands.Execute(new ConsolePlayer(), string.Format(command, player.CSteamID));
    }
}