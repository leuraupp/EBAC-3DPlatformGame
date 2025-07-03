using Ebac.Core.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth {
    public enum ClothType {
        DEFAULT,
        SPEED,
        STRONG,
        GRAVITY
    }

    public class ClothManager : Singleton<ClothManager> {
        public List<ClothSetup> clothSetups;

        public ClothSetup GetClothSetup(ClothType clothType) {
            return clothSetups.Find(setup => setup.clothType == clothType);
        }
    }

    [System.Serializable]
    public class ClothSetup {
        public ClothType clothType;
        public Texture2D texture;
    }
}
