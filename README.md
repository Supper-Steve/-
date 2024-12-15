# MusicDummy - 放歌假人[EXILED]🎵

<br>

# **介绍🤔**

## 该插件依赖EXILED 8.14.0

## MusicDummy添加了几种简单快捷的假人

## 你可以用这些假人去播放音乐

## 你可以引用这个插件，该插件依赖[SCPSLAudioAPI](https://github.com/CedModV2/SCPSLAudioApi)</br></br>

# **示例🔨**

## 该插件共5个方法，1个扩展

## 这是插件使用的示例

```
//添加一个Id为114,名称为史蒂夫的假人

MusicDummy.Dummy.Add(114,"史蒂夫");

//删除Id为114的假人

MusicDummy.Dummy.Remove(114);

//清除所有假人

MusicDummy.Dummy.Clear();

//使Id为114的假人,播放EXILED路径内的史蒂夫.ogg[48000采样率 单声道]

MusicDummy.Dummy.PlayAudio(114,Exiled.API.Features.Paths.Exiled + "\\史蒂夫.ogg");

//使Id为114的假人停止播放音乐
MusicDummy.Dummy.StopAudio(114);
```

## 对于Player💪，可以这样对玩家播放音乐

```
//赋值Player类的player

Player player;

//使Id为114的假人,对该玩家播放EXILED路径内的史蒂夫.ogg[48000采样率 单声道]

player.PlayAudio(114,Exiled.API.Features.Paths.Exiled + "\\史蒂夫.ogg");
```

## 这样你就能使用MusicDummy这个API了🔊</br></br>

# **使用💻**

## 首先下载 dependencies.zip 然后解压到\EXILED\Plugins\dependencies\内
## 然后讲MusicDummy.dll 放入\EXILED\Plugins\dependencies\内
## 你就能就能使用这个API了🎈</br></br>

# **作者📕**
# *史蒂夫 🐧3251808715*
