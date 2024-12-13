using UnityEngine;

namespace BuilderPattern
{
    // 武器工厂用于创建武器实例，可以扩展为根据不同的参数创建不同类型的武器
    public class WeaponFactory : MonoBehaviour
    {
        public static Weapon CreateWeapon(GameObject go, string weaponId)
        {
            var weapon = go.AddComponent<Weapon>();
            weapon.weaponId = weaponId;
            return weapon;
        }
    }
}