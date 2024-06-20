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
        // Ожидаем 8 секунд
        yield return new WaitForSeconds(8);
        // Выполняем команду бана в основном потоке
        R.Commands.Execute(new ConsolePlayer(), $"/ban {player.CSteamID} Cheating");
    }
}