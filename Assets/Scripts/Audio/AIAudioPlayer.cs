using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio {
    public class AIAudioPlayer : MonoBehaviour {

        public Audio.AudioController audioController;

        public AudioType spawnSound;
        public AudioType deathSound;
        public AudioType[] walkSounds;
        public AudioType[] attackSounds;
        public AudioType[] takeDamageSounds;

        // Get reference to audioController here
        private void Start() {
            audioController = GameObject.FindWithTag("AudioManager").GetComponent<Audio.AudioController>();
        }

        public void PlaySpawnSound() {
            audioController.PlayAudio(spawnSound);
        }

        public void PlayDeathSound() {
            audioController.PlayAudio(deathSound);
        }

        public void PlayWalkSound() {
            int randomIndex = Random.Range(0,walkSounds.Length);
            audioController.PlayAudio(walkSounds[randomIndex]);
        }

        public void PlayAttackSound() {
            int randomIndex = Random.Range(0,attackSounds.Length);
            audioController.PlayAudio(attackSounds[randomIndex]);
        }

        public void PlayTakingDamageSound() {
            int randomIndex = Random.Range(0,takeDamageSounds.Length);
            audioController.PlayAudio(takeDamageSounds[randomIndex]);
        }

    }

}

