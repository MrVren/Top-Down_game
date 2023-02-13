using UnityEngine;

namespace EtA
{
    public class Spawner : MonoBehaviour
    {
        public static Spawner instance;

        #region Properties for spawning animals
        private float _spawnRangeX = 15f;
        private float _spawnPosZ = 20f;

        private float startDelay = 2f;
        private float spawnInterval = 1.5f;
        #endregion

        public GameObject[] animalPrefabs;
        public GameObject playerPrefab;


        #region MonoBehaviour

        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            SpawnPlayer();
            InvokeRepeating(nameof(SpawnAnimals), startDelay, spawnInterval);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        #endregion

        private void SpawnPlayer()
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }

        public void SpawnAnimals()
        {
            Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnPosZ);
            int index = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[index], spawnPos, animalPrefabs[index].transform.rotation);
        }
    }
}