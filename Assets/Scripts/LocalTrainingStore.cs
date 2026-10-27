using System.Collections.Generic; using System.IO; using UnityEngine;
namespace VirtuWild { public sealed class LocalTrainingStore:MonoBehaviour {
  public List<TrainingRecord> Records {get; private set;}=new(); public List<EquipmentCard> Equipment {get; private set;}=new(); string Path=>System.IO.Path.Combine(Application.persistentDataPath,"virtuwild_records.json");
  [System.Serializable] class Wrapper { public List<TrainingRecord> records=new(); public List<EquipmentCard> equipment=new(); }
  void Awake(){Load(); if(Equipment.Count==0) Equipment.AddRange(new[]{new EquipmentCard{id="helmet",title="头盔与下颏带",guidance="检查外壳、扣具和贴合"},new EquipmentCard{id="harness",title="主伞/备份伞与连接带",guidance="按教练清单逐项确认"},new EquipmentCard{id="reserve",title="通讯与备份方案",guidance="确认电量、通讯和撤离计划"}});}
  public void SaveRecord(TrainingRecord r){if(r!=null){Records.Add(r);Save();}}
  public void MarkUnderstood(string id){var c=Equipment.Find(x=>x.id==id);if(c!=null){c.understood=true;Save();}}
  public void Save(){File.WriteAllText(Path,JsonUtility.ToJson(new Wrapper{records=Records,equipment=Equipment},true));}
  void Load(){if(!File.Exists(Path))return; var w=JsonUtility.FromJson<Wrapper>(File.ReadAllText(Path)); if(w!=null){Records=w.records??new();Equipment=w.equipment??new();}}
 }
}
