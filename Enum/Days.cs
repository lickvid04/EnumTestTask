 using System;
 using System.ComponentModel;
 
 /// <summary>
 /// Дни недели
 /// </summary>
 namespace TMK.NETCore.Extensions; 

 [Flags]
 public enum Days {
     /// <summary>
     /// Не выбрано
     /// </summary>
     [Description("Не выбрано")]
     None = 0x0,
     /// <summary>
     /// Понедельник
     /// </summary>
     [Description("Понедельник")]
     Monday = 0x1,
     /// <summary>
     /// Вторник
     /// </summary>
     [Description("Вторник")]
     Tuesday = 0x2,
     /// <summary>
     /// Среда
     /// </summary>
     [Description("Среда")]
     Wednesday = 0x4,
     /// <summary>
     /// Четверг
     /// </summary>
     [Description("Четверг")]
     Thursday = 0x8,
     /// <summary>
     /// Пятница
     /// </summary>
     [Description("Пятница")]
     Friday = 0x10,
     /// <summary>
     /// Суббота
     /// </summary>
     [Description("Суббота")]
     Saturday = 0x20,
     /// <summary>
     /// Воскресенье
     /// </summary>
     [Description("Воскресенье")]
     Sunday = 0x40
 }