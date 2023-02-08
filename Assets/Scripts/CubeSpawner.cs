using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
   [SerializeField]
   private СhangeСolorСube _prefabCube;
   private void Update()
   {
      if (Input.GetKey(KeyCode.Space))
      {
       var cube = Instantiate(_prefabCube);
       cube.transform.position = new Vector3(Random.Range(20, -20), 15, 0);
       Destroy(cube,30);
      }
   }
   
}
