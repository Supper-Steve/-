using Exiled.API.Features;
using SCPSLAudioApi.AudioCore;

namespace MusicDummy
{
    public static class Extensions
    {
        /// <summary>
        /// 向玩家播放音乐
        /// </summary>
        /// <param name="player"></param>
        /// <param name="Id">假人Id</param>
        /// <param name="Paths">路径[完整文件路径+扩展名]</param>
        /// <returns></returns>
        public static AudioPlayerBase PlayAudio(this Player player, int Id, string Paths)
        {
            if (!Dummy.List.ContainsKey(Id))
                Dummy.Add(Id, "Bot");
            Log.Info($"向玩家{player.Nickname}播放音乐[{Paths}]");
            ReferenceHub component = Dummy.List[Id].ReferenceHub;
            AudioPlayerBase audioPlayerBase = AudioPlayerBase.Get(component);
            string str = Paths;
            audioPlayerBase.Enqueue(str, -1);
            audioPlayerBase.LogDebug = false;
            audioPlayerBase.BroadcastTo.Add(player.Id);
            audioPlayerBase.Volume = 50f;
            audioPlayerBase.Loop = false;
            audioPlayerBase.Play(0);
            return audioPlayerBase;
        }
    }
}
