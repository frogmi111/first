using UnityEngine;
namespace VirtuWild {
 public sealed class ComfortSafetyController : MonoBehaviour {
  [SerializeField] Transform xrOrigin; [SerializeField] Transform stableHoverPoint; [SerializeField] Canvas pauseCanvas;
  public bool IsPaused {get; private set;}
  public void TogglePause(){IsPaused=!IsPaused; Time.timeScale=IsPaused?0f:1f; if(pauseCanvas) pauseCanvas.enabled=IsPaused;}
  public void ReturnToStableHover(){ if(xrOrigin&&stableHoverPoint){xrOrigin.SetPositionAndRotation(stableHoverPoint.position,stableHoverPoint.rotation);} }
  public void ResetAfterCollision(){ ReturnToStableHover(); IsPaused=false; Time.timeScale=1f; if(pauseCanvas) pauseCanvas.enabled=false; }
  void OnDestroy(){Time.timeScale=1f;}
 }
}
