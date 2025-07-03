using UnityEngine;

namespace Cloth {
    public class ClothChanger : MonoBehaviour {
        public SkinnedMeshRenderer mesh;

        public Texture2D texture;
        public string shaderName = "_EmissionMap";

        private Texture2D defaultTexture;

        private void Awake() {
            defaultTexture = mesh.materials[0].GetTexture(shaderName) as Texture2D;
        }

        [NaughtyAttributes.Button("Change Texture")]
        private void ChangeTexture() {
            mesh.materials[0].SetTexture(shaderName, texture);
        }

        public void ChangeTexture(ClothSetup clothSetup) {
            mesh.materials[0].SetTexture(shaderName, clothSetup.texture);
        }

        public void ResetTexture() {
            mesh.materials[0].SetTexture(shaderName, defaultTexture);
        }
    }
}