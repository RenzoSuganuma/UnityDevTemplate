using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyCompany.MyProj.Infra.TimeLineEx.Haptics
{
    public class HapticsPlayableClip : PlayableAsset
    {
        [SerializeField] private HapticsOperatingMode _operatingMode;
        [SerializeField] float _lowFrequency;
        [SerializeField] float _highFrequency;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<HapticsPlayableBehaviour>.Create(graph,
                new HapticsPlayableBehaviour(_operatingMode, _lowFrequency, _highFrequency));
        }
    }
}