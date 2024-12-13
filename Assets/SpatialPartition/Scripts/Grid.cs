using UnityEngine;

namespace SpatialPartition.Scripts
{
    // 网格类，同时处理战斗
    public class Grid
    {
        public const int NUM_CELLS = 6;
        public const int CELL_SIZE = 6;

        private Unit[] cells;

        // 网格上有多少单位，这比遍历所有单元格并计数更快
        public int unitCount { get; private set; }

        public Grid()
        {
            cells = new Unit[NUM_CELLS * NUM_CELLS];
            for (var x = 0; x < NUM_CELLS; x++)
            {
                for (var y = 0; y < NUM_CELLS; y++)
                {
                    cells[GetIndex(x, y)] = null;
                }
            }
        }

        private int GetIndex(int x, int y)
        {
            return (y * NUM_CELLS) + x;
        }

        // 添加单位到网格
        // 当单位已经在网格中并移动到新单元格时也会使用此方法
        public void Add(Unit newUnit, bool isNewUnit = false)
        {
            // 确定单位所在的网格单元格
            Vector2Int cellPos = ConvertFromWorldToCell(newUnit.transform.position);
            // 将单位添加到该单元格列表的前面
            newUnit.prev = null;
            newUnit.next = cells[GetIndex(cellPos.x, cellPos.y)];
            // 将单元格与该单位关联
            cells[GetIndex(cellPos.x, cellPos.y)] = newUnit;
            // 如果该单元格中已经有单位，它应该指向新单位
            if (newUnit.next != null)
            {
                newUnit.next.prev = newUnit;
            }

            if (isNewUnit)
            {
                unitCount += 1;
            }
        }

        // 移动网格上的单位 = 查看它是否改变了单元格
        // 确保 newPos 是网格内的有效位置
        public void Move(Unit unit, Vector3 oldPos, Vector3 newPos)
        {
            // 查看它之前所在的单元格
            Vector2Int oldCellPos = ConvertFromWorldToCell(oldPos);
            // 查看它移动到的单元格
            Vector2Int newCellPos = ConvertFromWorldToCell(newPos);
            // 如果它没有改变单元格，我们已完成
            if (oldCellPos.x == newCellPos.x && oldCellPos.y == newCellPos.y)
            {
                return;
            }

            // 从旧单元格的链表中取消链接
            UnlinkUnit(unit);
            // 如果该单位是该单元格链表的头，移除它
            if (cells[GetIndex(oldCellPos.x, oldCellPos.y)] == unit)
            {
                cells[GetIndex(oldCellPos.x, oldCellPos.y)] = unit.next;
            }

            // 将其添加回网格中的新单元格
            Add(unit);
        }

        // 从链表中取消链接单位
        private void UnlinkUnit(Unit unit)
        {
            if (unit.prev != null)
            {
                // 前一个单位应该获得一个新的下一个单位
                unit.prev.next = unit.next;
            }

            if (unit.next != null)
            {
                // 下一个单位应该获得一个新的前一个单位
                unit.next.prev = unit.prev;
            }
        }

        // 帮助方法，将 Vector3 转换为单元格位置
        public Vector2Int ConvertFromWorldToCell(Vector3 pos)
        {
            // 将坐标除以单元格大小，从世界空间转换为单元格空间
            // 转换为 int 类型，从单元格空间转换为单元格索引
            int cellX = Mathf.FloorToInt(pos.x / CELL_SIZE);
            int cellY = Mathf.FloorToInt(pos.z / CELL_SIZE); // z 而不是 y，因为 y 是 Unity 坐标系中的向上轴
            var cellPos = new Vector2Int(cellX, cellY);
            return cellPos;
        }

        // 测试位置是否为有效位置（= 是否在网格内）
        public bool IsPosValid(Vector3 pos)
        {
            Vector2Int cellPos = ConvertFromWorldToCell(pos);
            return cellPos.x is >= 0 and < NUM_CELLS && cellPos.y is >= 0 and < NUM_CELLS;
        }

        // 战斗处理
        public void HandleMelee()
        {
            for (var x = 0; x < NUM_CELLS; x++)
            {
                for (var y = 0; y < NUM_CELLS; y++)
                {
                    HandleCell(x, y);
                }
            }
        }

        // 处理单个单元格的战斗
        private void HandleCell(int x, int y)
        {
            Unit unit = cells[GetIndex(x, y)];
            // 让该单元格中的每个单位与其他单位战斗一次
            while (unit != null)
            {
                // 尝试与该单元格中的其他单位战斗
                HandleUnit(unit, unit.next);
                // 我们还应该尝试与周围8个单元格中的单位战斗，因为它们可能也在攻击范围内
                // 但我们不能检查所有8个单元格，因为这样有些单位可能会战斗两次，所以我们只检查一半（哪一半不重要）
                // 我们还必须检查是否有周围的单元格，因为当前单元格可能是边界
                // 这假设攻击距离小于单元格大小，否则我们可能需要检查更多单元格
                if (x > 0 && y > 0)
                {
                    HandleUnit(unit, cells[GetIndex(x - 1, y - 1)]);
                }

                if (x > 0)
                {
                    HandleUnit(unit, cells[GetIndex(x - 1, y - 0)]);
                }

                if (y > 0)
                {
                    HandleUnit(unit, cells[GetIndex(x - 0, y - 1)]);
                }

                if (x > 0 && y < NUM_CELLS - 1)
                {
                    HandleUnit(unit, cells[GetIndex(x - 1, y + 1)]);
                }

                unit = unit.next;
            }
        }

        // 处理单个单位与链表中的单位的战斗
        private void HandleUnit(Unit unit, Unit other)
        {
            while (other != null)
            {
                // 如果它们的位置相似，则让它们战斗 - 使用平方距离因为它更快
                if ((unit.transform.position - other.transform.position).sqrMagnitude < Unit.ATTACK_DISTANCE * Unit.ATTACK_DISTANCE)
                {
                    HandleAttack(unit, other);
                }

                //更新 other 变量，使其指向链表中的下一个单位。这样在下一次循环迭代时，将检查当前单位与下一个单位之间的距离
                other = other.next;
            }
        }

        // 处理两个单位之间的攻击
        private void HandleAttack(Unit one, Unit two)
        {
            // 插入战斗机制
            one.StartFighting();
            two.StartFighting();
        }
    }
}