using System;
using System.Collections.Generic;
using UnityEngine;

namespace VirtuWild {
    public enum TrainingStage { Recognition, GroundPrep, GuidedAvoidance, RandomChallenge, Review }
    public enum ScenarioId { Canyon, CoastalCliff }
    [Serializable] public class ObstacleSpec { public string id; public Vector3 position; public float radius = 4f; }
    [Serializable] public class ScenarioConfig { public string id; public string displayName; public string skybox; public List<ObstacleSpec> route = new(); public Vector3 safeHover; }
    [Serializable] public class TrainingRecord { public string sessionId; public string scenario; public int detected; public int avoided; public int collisions; public float averageReactionSeconds; public bool exitedEarly; public long startedUtc; }
    [Serializable] public class EquipmentCard { public string id; public string title; public string guidance; public bool understood; }
}
