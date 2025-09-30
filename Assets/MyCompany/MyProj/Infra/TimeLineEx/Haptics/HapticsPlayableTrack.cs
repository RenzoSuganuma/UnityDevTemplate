using System;
using UnityEngine;
using UnityEngine.Timeline;

namespace MyCompany.MyProj.Infra.TimeLineEx.Haptics
{
    [Serializable]
    [TrackClipType(typeof(HapticsPlayableClip))]
    public class HapticsPlayableTrack : PlayableTrack
    {
    }
}