using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace BasketBall
{
    public class CheckBoxColliderSystem : IEcsRunSystem
    {
        EcsFilter<CellOccupiedComponent> _filter;
        SceneData _sceneData;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var cellOccupiedData = ref _filter.Get1(i);
                var collider = cellOccupiedData.collider;
                if( collider == null )
                {
                    return;
                }
                Collider[] hitColliders = Physics.OverlapBox(cellOccupiedData.box.transform.position, cellOccupiedData.collider.bounds.size / 2f, cellOccupiedData.box.transform.rotation);
                foreach (var hit in hitColliders)
                {
                    if (cellOccupiedData.box.transform.position != hit.transform.position)
                    {
                        if (hit.tag == "Box")
                        {
                            //Debug.Log("sfg");
                            GameObject.Destroy(cellOccupiedData.box);
                        }
                        else if (hit.tag == "Coin")
                        {
                            GameObject.Destroy(hit.gameObject, 0.8f);

                            Vector3 targetPosition = new Vector3(hit.gameObject.transform.position.x, hit.gameObject.transform.position.y + 10f, hit.gameObject.transform.position.z);
                            hit.gameObject.transform.position = Vector3.MoveTowards(hit.gameObject.transform.position, targetPosition, 1 * Time.deltaTime);

                            Quaternion targetRot = Quaternion.Euler(0,4,0);
                            hit.gameObject.transform.rotation *= targetRot;

                            _sceneData.CoinCounter++;
                        }
                    }
                }
            }
        }
    }
}