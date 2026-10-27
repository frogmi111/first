using System; using UnityEngine; using UnityEngine.Events;
namespace VirtuWild {
 public sealed class TrainingSessionController : MonoBehaviour {
  public TrainingStage Stage { get; private set; } = TrainingStage.Recognition;
  public ScenarioId Scenario { get; private set; } = ScenarioId.Canyon;
  public TrainingRecord Current { get; private set; }
  public UnityEvent<TrainingStage> StageChanged = new(); public UnityEvent<TrainingRecord> SessionEnded = new();
  float stageStarted; bool running;
  public void Begin(ScenarioId scenario) { Scenario=scenario; Current=new TrainingRecord{sessionId=Guid.NewGuid().ToString("N"),scenario=scenario.ToString(),startedUtc=DateTimeOffset.UtcNow.ToUnixTimeSeconds()}; SetStage(TrainingStage.Recognition); running=true; }
  public void Advance() { if(!running) return; if(Stage<TrainingStage.Review) SetStage(Stage+1); else End(false); }
  public void SetStage(TrainingStage next) { Stage=next; stageStarted=Time.time; StageChanged.Invoke(Stage); }
  public void RecordDetection(bool avoided,float reactionSeconds) { if(Current==null) return; Current.detected++; if(avoided) Current.avoided++; Current.averageReactionSeconds=((Current.averageReactionSeconds*(Current.detected-1))+reactionSeconds)/Current.detected; }
  public void RecordCollision() { if(Current!=null) Current.collisions++; }
  public void End(bool exitedEarly) { if(!running) return; running=false; if(Current!=null) Current.exitedEarly=exitedEarly; SessionEnded.Invoke(Current); }
 }
}
