using Exiled.API.Features;
using Mirror;
using SCPSLAudioApi.AudioCore;
using System.Collections.Generic;
using UnityEngine;
using VoiceChat;

namespace MusicDummy
{
    public static class Dummy
    {
        /// <summary>
        /// 假人列表
        /// </summary>
        public static Dictionary<int, Player> List = new Dictionary<int, Player>();
        /// <summary>
        /// 清除所以假人
        /// </summary>
        public static void Clear()
        {
            foreach (int Id in List.Keys)
            {
                AudioPlayerBase audioPlayerBase = AudioPlayerBase.Get(List[Id].ReferenceHub);
                if (audioPlayerBase.CurrentPlay != null)
                {
                    audioPlayerBase.Stoptrack(true);
                    audioPlayerBase.OnDestroy();
                }
                try
                {
                    NetworkServer.RemovePlayerForConnection(List[Id].Connection, true);
                }
                catch
                {

                }
            }
            Log.Info($"删除了所有的假人");
            List.Clear();
        }
        /// <summary>
        /// 删除假人
        /// </summary>
        /// <param name="Id">假人Id</param>
        public static void Remove(int Id)
        {
            AudioPlayerBase audioPlayerBase = AudioPlayerBase.Get(List[Id].ReferenceHub);
            if (audioPlayerBase.CurrentPlay != null)
            {
                audioPlayerBase.Stoptrack(true);
                audioPlayerBase.OnDestroy();
            }
            try
            {
                NetworkServer.RemovePlayerForConnection(List[Id].Connection,true);
            }
            catch
            {

            }
            Log.Info($"删除了所有的假人");
            List.Clear();
        }
        /// <summary>
        /// 播放音乐
        /// 当没有假人Id不存在时会创建假人
        /// </summary>
        /// <param name="Id">假人Id</param>
        /// <param name="Paths">路径[完整文件路径+扩展名]</param>
        /// <returns></returns>
        public static AudioPlayerBase PlayAudio(int Id, string Paths)
        {
            if (!List.ContainsKey(Id))
                Add(Id, "Bot");
            Log.Info($"播放音乐[{Paths}]");
            ReferenceHub component = List[Id].ReferenceHub;
            AudioPlayerBase audioPlayerBase = AudioPlayerBase.Get(component);
            string str = Paths;
            audioPlayerBase.Enqueue(str, -1);
            audioPlayerBase.LogDebug = false;
            audioPlayerBase.BroadcastChannel = VoiceChatChannel.Intercom;
            audioPlayerBase.Volume = 50f;
            audioPlayerBase.Loop = false;
            audioPlayerBase.Play(0);
            return audioPlayerBase;
        }
        /// <summary>
        /// 停止播放音乐
        /// </summary>
        /// <param name="Id">假人Id</param>
        /// <returns></returns>
        public static void StopAudio(int Id)
        {
            AudioPlayerBase audioPlayerBase = AudioPlayerBase.Get(List[Id].ReferenceHub);
            if (audioPlayerBase.CurrentPlay != null)
            {
                audioPlayerBase.Stoptrack(true);
                audioPlayerBase.OnDestroy();
            }
        }
        /// <summary>
        /// 添加假人
        /// </summary>
        /// <param name="Id">假人Id</param>
        /// <param name="Name">假人名</param>
        /// <returns></returns>
        public static void Add(int Id, string Name = "Bot")
        {
            if (List.ContainsKey(Id))
                return;
            Log.Info($"添加了Id为{Id},名称为{Name}的假人");
            GameObject player1 = Object.Instantiate(NetworkManager.singleton.playerPrefab);
            NetworkServer.AddPlayerForConnection(new FakeConnection(Id), player1);
            ReferenceHub component = player1.GetComponent<ReferenceHub>();
            Player player = Player.Get(component);
            player.DisplayNickname = Name;
            List.Add(Id, player);
        }
    }
}
