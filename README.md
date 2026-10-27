# VirtuWild 虚野行

Unity URP + OpenXR/XR Interaction Toolkit 的 PC‑VR 地面辅助预演原型。

> VR 仅用于地面辅助预演，不能替代真实专业教学，也不授予飞行资格。项目不采集或训练生理心率，仅记录障碍识别、反应时间、避障成功率与路线决策。

## 导入

1. Unity Hub 创建/打开 Unity 2022.3 LTS（URP）项目，将本仓库作为项目根目录。
2. Package Manager 安装 `com.unity.xr.openxr`、`com.unity.xr.interaction.toolkit`、`com.unity.inputsystem`。
3. 在 Project Settings > XR Plug-in Management 启用 OpenXR（Standalone/Windows），启用 Hand Tracking 或控制器交互配置。
4. 打开 `Assets/Scenes/VirtuWildDemo.unity`（或按 `Assets/Scenes/README.md` 创建演示场景），将 `VirtuWildBootstrap` 挂到空物体并运行。

## 体验流程

认识选择 → 地面准备学习 → 引导式空中避障 → 随机障碍挑战 → 训练复盘。任意阶段可暂停、回到稳定悬停观景位、碰撞后一键重置；退出会保存本地记录且不判定失败。

## 目录

- `Assets/Scripts/`：状态机、训练会话、障碍、悬停安全、装备清单、记录持久化、UI 控制器。
- `Assets/Configs/`：峡谷/海岸悬崖场景与障碍路线 JSON。
- `Assets/Scenes/`：场景搭建说明与占位场景元数据。

开源地形/HDRI 请在 Unity Asset Store 或 Poly Haven 导入后替换占位物体；源码不捆绑第三方资产。
