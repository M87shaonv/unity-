using System.Collections;
using UnityEngine;

namespace SpatialPartition.Scripts
{
    public class Unit : MonoBehaviour
    {
        public GameObject unitBody;
        private Grid grid;
        [System.NonSerialized] public Unit prev;
        [System.NonSerialized] public Unit next;
        private MeshRenderer meshRenderer;
        private Color unitColor = Color.white;
        private float unitSpeed;

        public const float ATTACK_DISTANCE = 1.0f;

        private void Awake()
        {
            meshRenderer = unitBody.GetComponent<MeshRenderer>();
            if (meshRenderer == null)
            {
                Debug.LogError("MeshRenderer not found on unit body.");
            }

            unitSpeed = Random.Range(1f, 5f);
            meshRenderer.material.color = unitColor;
        }

        public void InitUnit(Grid grid, Vector3 startPos)
        {
            this.grid = grid ?? throw new System.ArgumentNullException(nameof(grid), "Grid cannot be null when initializing a unit.");

            transform.position = startPos;
            prev = null;
            next = null;

            grid.Add(this, true);
            transform.rotation = GetRandomDirection();
        }

        public void Move(float dt)
        {
            Vector3 oldPos = transform.position;
            Vector3 newPos = oldPos + (transform.forward * (unitSpeed * dt));

            bool isValid = grid != null && grid.IsPosValid(newPos); // 新位置是否是网格内的有效位置
            if (isValid)
            {
                transform.position = newPos;
                grid.Move(this, oldPos, newPos); // 更新网格，因为单位可能已经改变了单元格
            }
            else
            {
                // 尝试找到一个新的有效方向
                for (var i = 0; i < 10; i++) // 尝试最多10次
                {
                    transform.rotation = GetRandomDirection();
                    newPos = oldPos + (transform.forward * (unitSpeed * dt));
                    if (grid.IsPosValid(newPos))
                    {
                        transform.position = newPos;
                        grid.Move(this, oldPos, newPos);
                        break;
                    }
                }
            }
        }

        private Quaternion GetRandomDirection()
        {
            return Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
        }

        public void StartFighting()
        {
            StopAllCoroutines(); // 停止所有 FightCooldown 协程
            StartCoroutine(FightCooldown());
        }

        private IEnumerator FightCooldown()
        {
            meshRenderer.sharedMaterial.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            meshRenderer.sharedMaterial.color = unitColor;
        }
    }
}