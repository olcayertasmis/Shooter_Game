using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "New Game Data")]
    public class GameData : ScriptableObject
    {
        public Scene loadingScene;
    } // END CLASS
}