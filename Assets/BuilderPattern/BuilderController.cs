using UnityEngine;

namespace BuilderPattern
{
    public class BuilderController : MonoBehaviour
    {
        private void Start()
        {
            // 创建一个没有武器的怪物
            var buildParam1001 = new MonsterBuilderParam("monster_1001", "Monster", 100, 100, 0, 50);
            var monsterBuilder = new MonsterBuilder(buildParam1001);
            var monster = (Monster)monsterBuilder.ConstructFull();
            monster.transform.position = new Vector3(0, 0, 0);

            // 创建携带武器weapon002的怪物
            var buildParam1002 = new MonsterBuilderParam("monster_1002", "Monster", 100, 100, 20, 50, "weapon002");
            monsterBuilder.Reset(buildParam1002);
            var monster2 = (Monster)monsterBuilder.ConstructFull();
            monster2.transform.position = new Vector3(2, 0, 0);

            // 创建一个最基础的怪物，不设置属性
            var buildParam1003 = new MonsterBuilderParam("monster_1003", "Monster");
            monsterBuilder.Reset(buildParam1003);
            var monster3 = (Monster)monsterBuilder.ConstructMinimal();
            monster3.transform.position = new Vector3(4, 0, 0);

            // 创建一只跟随monster3的宠物
            var petBuilderParam = new PetBuilderParam("pet_1001", "Pet", monster3.gameObject.transform);
            var petBuilder = new PetBuilder(petBuilderParam);
            //petBuilder.AddWeapon(); // 给宠物添加武器,报错
            var pet = (Pet)petBuilder.ConstructFull();
            pet.transform.position = new Vector3(5, 0, 0);
        }
    }
}