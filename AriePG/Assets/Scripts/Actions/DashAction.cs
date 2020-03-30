using UnityEngine;
using System.Collections;

namespace AriePG {
    [CreateAssetMenu(fileName = "DashAction", menuName = "ScriptableObjects/Actions/DashAction", order = 1)]
    public class DashAction : Action {
        public int frameCount;
        public float dashSpeed;

        public override IEnumerator Execute(Player player) {

            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float originalMovespeed = player.movementspeed;
            for(int i = 0; i < frameCount; i++) {
                player.movement = targetPos - (Vector2) player.transform.position;
                player.movementspeed = dashSpeed;
                yield return 0;
            }
            player.movementspeed = originalMovespeed;
            player.busy = false;
        }
    }
}