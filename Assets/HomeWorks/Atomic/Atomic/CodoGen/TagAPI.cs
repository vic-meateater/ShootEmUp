/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;

namespace Atomic.Entities
{
    public static class TagAPI
    {
        ///Keys
        public const int PlayerTag = 1;


        ///Extensions
        public static bool HasPlayerTagTag(this IEntity obj) => obj.HasTag(PlayerTag);
        public static bool AddPlayerTagTag(this IEntity obj) => obj.AddTag(PlayerTag);
        public static bool DelPlayerTagTag(this IEntity obj) => obj.DelTag(PlayerTag);
    }
}
