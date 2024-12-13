using UnityEngine;

namespace PrototypePattern.MonsterSpawner
{
    public class SpawnController : MonoBehaviour
    {
        // 每种类型的怪物都有一个对应的原型
        private Ghost ghostPrototype;
        private Demon demonPrototype;
        private Sorcerer sorcererPrototype;

        // monsterSpawners 数组保存了所有可用的 Spawner 实例
        private Spawner[] monsterSpawners;

        private void Start()
        {
            // 初始化每种怪物类型的原型。
            ghostPrototype = new Ghost(15, 3);
            demonPrototype = new Demon(11, 7);
            sorcererPrototype = new Sorcerer(4, 11);

            // 初始化 Spawner 数组，为每种怪物类型提供一个 Spawner
            monsterSpawners = new Spawner[] {
                new(ghostPrototype),
                new(demonPrototype),
                new(sorcererPrototype),
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var ghostSpawner = new Spawner(ghostPrototype);
                var newGhost = ghostSpawner.SpawnMonster() as Ghost;

                // 调用新鬼魂的 Talk 方法，输出一条消息到控制台
                newGhost.Talk();

                // 随机选择一个 Spawner 来生成一个随机类型的怪物
                Spawner randomSpawner = monsterSpawners[Random.Range(0, monsterSpawners.Length)];
                _Monster randomMonster = randomSpawner.SpawnMonster();

                // 调用新生成的随机怪物的 Talk 方法。
                randomMonster.Talk();
            }
        }
    }
}