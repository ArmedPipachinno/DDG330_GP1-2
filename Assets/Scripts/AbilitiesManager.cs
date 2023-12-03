using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbilitiesManager : MonoBehaviour
{
    [SerializeField] private Movement MovementAbilities;
    [SerializeField] private HPManager HPHeal;
    [SerializeField] private Spawner SpawnerAccel;
    [SerializeField] private SceneManagement WLoader;

    [SerializeField] private string SpeedAbilities = "SpeedBoost";
    [SerializeField] private string Heal = "HP+";
    [SerializeField] private string SpawnBoost = "More Target";
    [SerializeField] private string Win = "W";

    public void ActiveAbilities(Item item)
    {
        // Comepare Item Name
        if (item._Name == SpeedAbilities) // Change "DoubleSpeedItem" to the actual name of your double speed item
        {
            MovementAbilities.ActivateSpeed();
        }
        else if (item._Name == Heal)
        {
            HPHeal.Healplayer();
        }
        else if (item._Name == SpawnBoost)
        {
            SpawnerAccel.SpawnMoretarget();
        }
        else if (item._Name == Win)
        {
            WLoader.EndW();
        }
            

        else
        {
            Debug.Log("Shop Entry Error");
        }
    }

    public void ActivateCall(string Caller)
    {
        Debug.Log($"Activate: {Caller}");
    }
}
