using UnityEngine;
using System.Collections;

namespace AriePG {
    [CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/Actions/Move", order = 1)]
    public class MoveAction : Action {

        [SerializeField] private Vector2 move;
        public override IEnumerator Execute(Player player) {
            player.movement += move;
            yield return 0;
            player.busy = false;
        }
    }
}