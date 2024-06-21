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


    public void BanPlayer(UnturnedPlayer player)
    {
        StartCoroutine(BanAfterDelay(player));
    }

    private IEnumerator BanAfterDelay(UnturnedPlayer player)
    {
        yield return new WaitForSeconds(8);
        PlayerSpeedManager.RestorePlayerSpeed(player.Player);
        string command = CEBPlugin.Config.BanCommand;
        R.Commands.Execute(new ConsolePlayer(), string.Format(command, player.CSteamID));
    }
}