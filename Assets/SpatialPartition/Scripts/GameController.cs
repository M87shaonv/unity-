using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartition.Scripts
{
    // 如果单位可以互相战斗，它们会改变颜色，并且颜色会保持一段时间以便观察效果
    public class GameController : MonoBehaviour
    {
        public Unit unitPrefab;
        public Transform unitParentTrans;

        private Grid grid;
        private const int NUMBER_OF_UNITS = 100; // 地图上移动的单位数量
        private HashSet<Unit> allUnits = new(); // 用于跟踪所有单位以便移动它们
        private Material gridMaterial;
        private Mesh gridMesh;

        private void Start()
        {
            grid = new Grid();

            float battlefieldWidth = Grid.NUM_CELLS * Grid.CELL_SIZE;

            for (var i = 0; i < NUMBER_OF_UNITS; i++)
            {
                float randomX = Random.Range(0f, battlefieldWidth);
                float randomZ = Random.Range(0f, battlefieldWidth);
                var randomPos = new Vector3(randomX, 0f, randomZ);

                Unit newUnit = Instantiate(unitPrefab, unitParentTrans);
                // 初始化单位，这会将其添加到网格中
                newUnit.InitUnit(grid, randomPos);
                // 将单位添加到所有单位的集合中
                allUnits.Add(newUnit);
            }
        }

        private void Update()
        {
            foreach (Unit unit in allUnits)
            {
                unit.Move(Time.deltaTime);
            }

            grid.HandleMelee();
        }

        private void LateUpdate()
        {
            // 显示网格
            if (gridMaterial == null)
            {
                // 创建网格材质并设置颜色为黑色
                gridMaterial = new Material(Shader.Find("Unlit/Color"));
                gridMaterial.color = Color.black;
            }

            if (grid == null)
            {
                return;
            }

            if (gridMesh == null)
            {
                // 初始化网格网格对象
                gridMesh = InitGridMesh();
            }

            // 绘制网格
            Graphics.DrawMesh(gridMesh, Vector3.zero, Quaternion.identity, gridMaterial, 0, Camera.main, 0);
        }

        private Mesh InitGridMesh()
        {
            // 生成顶点
            var lineVertices = new List<Vector3>();
            float battlefieldWidth = Grid.NUM_CELLS * Grid.CELL_SIZE;
            Vector3 linePosX = Vector3.zero;
            Vector3 linePosY = Vector3.zero;
            for (var x = 0; x <= Grid.NUM_CELLS; x++)
            {
                lineVertices.Add(linePosX);
                lineVertices.Add(linePosX + (Vector3.right * battlefieldWidth));
                lineVertices.Add(linePosY);
                lineVertices.Add(linePosY + (Vector3.forward * battlefieldWidth));
                linePosX += Vector3.forward * Grid.CELL_SIZE;
                linePosY += Vector3.right * Grid.CELL_SIZE;
            }

            // 生成索引
            var indices = new List<int>();
            for (var i = 0; i < lineVertices.Count; i++)
            {
                indices.Add(i);
            }

            // 生成网格
            var gridMesh = new Mesh();
            gridMesh.SetVertices(lineVertices);
            gridMesh.SetIndices(indices, MeshTopology.Lines, 0);
            return gridMesh;
        }
    }
}