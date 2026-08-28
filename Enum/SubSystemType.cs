 using System.ComponentModel;
 
 /// <summary>
 /// Типы подсистем 
 /// </summary>
 namespace TMK.NETCore.Extensions;
 public enum SubSystemType {
     /// <summary>
     /// Подсистема хранения данных
     /// </summary>
     [Description("Подсистема хранения данных")]
     Storage,
     /// <summary>
     /// Подсистема ведения справочников
     /// </summary>
     [Description("Подсистема ведения справочников")]
     Reference,
     /// <summary>
     /// Подсистема разграничения доступа
     /// </summary>
     [Description("Подсистема разграничения доступа")]
     AccessControl,
     /// <summary>
     /// Подсистема обработки данных
     /// </summary>
     [Description("Подсистема обработки данных")]
     DataProcessing,
     /// <summary>
     /// Подсистема рассылки оповещений
     /// </summary>
     [Description("Подсистема рассылки оповещений")]
     SendMsg,
     /// <summary>
     /// Подсистема взаимодействия с внешними системами
     /// </summary>
     [Description("Подсистема взаимодействия с внешними системами")]
     ExternalSystem,
     /// <summary>
     /// Подсистема журналирования
     /// </summary>
     [Description("Подсистема журналирования")]
     Logging,
     /// <summary>
     /// Подсистема отображения
     /// </summary>
     [Description("Подсистема отображения")]
     Display,
     /// <summary>
     /// Подсистема формирования отчетов
     /// </summary>
     [Description("Подсистема формирования отчетов")]
     Report,
     /// <summary>
     /// Подсистема хранения настроек системы
     /// </summary>
     [Description("Подсистема хранения настроек системы")]
     Settings
 }