using UnityEngine; using TMPro;
namespace VirtuWild { public sealed class VirtuWildUI:MonoBehaviour {
  public TrainingSessionController session; public LocalTrainingStore store; public TMP_Text stageLabel, safetyLabel, statsLabel;
  void OnEnable(){if(session)session.StageChanged.AddListener(UpdateStage); if(session)session.SessionEnded.AddListener(OnEnded);}
  void UpdateStage(TrainingStage s){if(stageLabel)stageLabel.text=$"阶段 {((int)s)+1}/5  ·  {s}"; if(safetyLabel)safetyLabel.text="VR 仅地面辅助预演｜随时暂停/稳定悬停｜不替代专业教学";}
  void OnEnded(TrainingRecord r){store?.SaveRecord(r); if(statsLabel)statsLabel.text=$"避障 {r.avoided}/{r.detected}  ·  平均反应 {r.averageReactionSeconds:0.00}s  ·  碰撞 {r.collisions}";}
  public void Pause(ComfortSafetyController c){c.TogglePause();} public void StableHover(ComfortSafetyController c){c.ReturnToStableHover();} public void ResetCollision(ComfortSafetyController c){c.ResetAfterCollision();} public void Exit(){session.End(true);}
 }
}
