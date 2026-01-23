using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Start()
    {
        //FindObjectsSortMode.None - we dont care how / if they are sorted
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
