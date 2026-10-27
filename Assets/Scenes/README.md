# 场景搭建

创建 `VirtuWildDemo.unity`：

1. 添加 XR Origin（Action-based）、Main Camera、Directional Light、Volume（Bloom/Color Adjustments）。
2. 添加 `VirtuWildBootstrap`、`TrainingSessionController`、`ComfortSafetyController`、`LocalTrainingStore`。
3. 放置两个场景根节点 `CanyonRoot` 与 `CoastalCliffRoot`，分别引用 `Assets/Configs/canyon.json`、`coastal_cliff.json`。
4. 用 Terrain/Prefab 替换占位地形，并将障碍物 Collider 标记为 `TrainingObstacle`。
5. Canvas 使用 World Space，青绿色半透明面板（#55D6C2，alpha 0.82），按钮绑定 `VirtuWildUI` 方法。

Windows 构建目标：PC、OpenXR、DX11/DX12；建议先在编辑器中用模拟 XR Device 验证流程，再打包 Standalone。
