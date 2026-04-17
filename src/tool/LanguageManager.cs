using BBSFW.Properties;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BBSFW
{
	public enum AppLanguage
	{
		English,
		Chinese,
		Norwegian
	}

	public static class LanguageManager
	{
		public static event EventHandler LanguageChanged;

		public static AppLanguage CurrentLanguage { get; private set; }

		private static readonly Dictionary<string, string> English = new()
		{
			["App.Subtitle"] = "Firmware settings, calibration, and diagnostics",
			["Splash.ControllerConfig"] = "Controller configuration",
			["Splash.PreparingWorkspace"] = "Preparing workspace",
			["Splash.Summary"] = "Firmware settings, calibration, and diagnostics",
			["Status.Connected"] = "Connected",
			["Status.Disconnected"] = "Disconnected",
			["Status.Firmware"] = "Firmware ",
			["Status.Ready"] = "Ready",
			["Status.ConfigVersion"] = "Config version ",
			["Status.Controller"] = " | Controller ",
			["Menu.File"] = "File",
			["Menu.Open"] = "Open...",
			["Menu.SaveAs"] = "Save As...",
			["Menu.SaveLog"] = "Save Log...",
			["Menu.Exit"] = "Exit",
			["Menu.Flash"] = "Flash",
			["Menu.Read"] = "Read",
			["Menu.Write"] = "Write",
			["Menu.Reset"] = "Reset",
			["Menu.Options"] = "Options",
			["Menu.Units"] = "Units",
			["Menu.Metric"] = "Metric",
			["Menu.Imperial"] = "Imperial",
			["Menu.DarkMode"] = "Dark Mode",
			["Menu.Language"] = "Language",
			["Menu.English"] = "English",
			["Menu.Chinese"] = "Chinese",
			["Menu.Norwegian"] = "Norwegian",
			["Menu.Help"] = "Help",
			["Menu.About"] = "About",
			["Theme.LightMode"] = "Light mode",
			["Theme.DarkMode"] = "Dark mode",
			["Theme.LightStatus"] = "Light mode",
			["Theme.DarkStatus"] = "Dark mode",
			["Tab.Connection"] = "Connection",
			["Tab.System"] = "System",
			["Tab.AssistLevels"] = "Assist Levels",
			["Tab.Calibration"] = "Calibration",
			["Tab.EventLog"] = "Event Log",
			["System.Global"] = "Global",
			["System.Throttle"] = "Throttle",
			["System.PedalAssist"] = "Pedal Assist",
			["System.Features"] = "Features",
			["System.SpeedShift"] = "Speed & Shift",
			["System.Display"] = "Display"
		};

		private static readonly Dictionary<string, string> Chinese = new()
		{
			["App.Subtitle"] = "固件设置、校准和诊断",
			["Splash.ControllerConfig"] = "控制器配置",
			["Splash.PreparingWorkspace"] = "正在准备工作区",
			["Splash.Summary"] = "固件设置、校准和诊断",
			["Status.Connected"] = "已连接",
			["Status.Disconnected"] = "未连接",
			["Status.Firmware"] = "固件 ",
			["Status.Ready"] = "就绪",
			["Status.ConfigVersion"] = "配置版本 ",
			["Status.Controller"] = " | 控制器 ",
			["Menu.File"] = "文件",
			["Menu.Open"] = "打开...",
			["Menu.SaveAs"] = "另存为...",
			["Menu.SaveLog"] = "保存日志...",
			["Menu.Exit"] = "退出",
			["Menu.Flash"] = "刷写",
			["Menu.Read"] = "读取",
			["Menu.Write"] = "写入",
			["Menu.Reset"] = "重置",
			["Menu.Options"] = "选项",
			["Menu.Units"] = "单位",
			["Menu.Metric"] = "公制",
			["Menu.Imperial"] = "英制",
			["Menu.DarkMode"] = "深色模式",
			["Menu.Language"] = "语言",
			["Menu.English"] = "英语",
			["Menu.Chinese"] = "中文",
			["Menu.Norwegian"] = "挪威语",
			["Menu.Help"] = "帮助",
			["Menu.About"] = "关于",
			["Theme.LightMode"] = "浅色模式",
			["Theme.DarkMode"] = "深色模式",
			["Theme.LightStatus"] = "浅色模式",
			["Theme.DarkStatus"] = "深色模式",
			["Tab.Connection"] = "连接",
			["Tab.System"] = "系统",
			["Tab.AssistLevels"] = "助力等级",
			["Tab.Calibration"] = "校准",
			["Tab.EventLog"] = "事件日志",
			["System.Global"] = "全局",
			["System.Throttle"] = "油门",
			["System.PedalAssist"] = "踏板助力",
			["System.Features"] = "功能",
			["System.SpeedShift"] = "速度与换挡",
			["System.Display"] = "显示"
		};

		private static readonly Dictionary<string, string> Norwegian = new()
		{
			["App.Subtitle"] = "Fastvareinnstillinger, kalibrering og diagnostikk",
			["Splash.ControllerConfig"] = "Kontrollerkonfigurasjon",
			["Splash.PreparingWorkspace"] = "Klargjør arbeidsområde",
			["Splash.Summary"] = "Fastvareinnstillinger, kalibrering og diagnostikk",
			["Status.Connected"] = "Tilkoblet",
			["Status.Disconnected"] = "Frakoblet",
			["Status.Firmware"] = "Fastvare ",
			["Status.Ready"] = "Klar",
			["Status.ConfigVersion"] = "Konfigurasjonsversjon ",
			["Status.Controller"] = " | Kontroller ",
			["Menu.File"] = "Fil",
			["Menu.Open"] = "Åpne...",
			["Menu.SaveAs"] = "Lagre som...",
			["Menu.SaveLog"] = "Lagre logg...",
			["Menu.Exit"] = "Avslutt",
			["Menu.Flash"] = "Flash",
			["Menu.Read"] = "Les",
			["Menu.Write"] = "Skriv",
			["Menu.Reset"] = "Tilbakestill",
			["Menu.Options"] = "Alternativer",
			["Menu.Units"] = "Enheter",
			["Menu.Metric"] = "Metrisk",
			["Menu.Imperial"] = "Imperial",
			["Menu.DarkMode"] = "Mørk modus",
			["Menu.Language"] = "Språk",
			["Menu.English"] = "Engelsk",
			["Menu.Chinese"] = "Kinesisk",
			["Menu.Norwegian"] = "Norsk",
			["Menu.Help"] = "Hjelp",
			["Menu.About"] = "Om",
			["Theme.LightMode"] = "Lys modus",
			["Theme.DarkMode"] = "Mørk modus",
			["Theme.LightStatus"] = "Lys modus",
			["Theme.DarkStatus"] = "Mørk modus",
			["Tab.Connection"] = "Tilkobling",
			["Tab.System"] = "System",
			["Tab.AssistLevels"] = "Assistansenivåer",
			["Tab.Calibration"] = "Kalibrering",
			["Tab.EventLog"] = "Hendelseslogg",
			["System.Global"] = "Globalt",
			["System.Throttle"] = "Gass",
			["System.PedalAssist"] = "Pedalassistanse",
			["System.Features"] = "Funksjoner",
			["System.SpeedShift"] = "Hastighet og giring",
			["System.Display"] = "Display"
		};

		public static void Initialize()
		{
			SetLanguage(Parse(Settings.Default.AppLanguage), false);
		}

		public static void SetLanguage(AppLanguage language)
		{
			SetLanguage(language, true);
		}

		public static string Get(string key)
		{
			return Application.Current.Resources[$"Loc.{key}"] as string ?? key;
		}

		private static void SetLanguage(AppLanguage language, bool save)
		{
			CurrentLanguage = language;

			foreach (var item in GetDictionary(language))
			{
				Application.Current.Resources[$"Loc.{item.Key}"] = item.Value;
			}

			if (save)
			{
				Settings.Default.AppLanguage = ToSetting(language);
				Settings.Default.Save();
			}

			LanguageChanged?.Invoke(null, EventArgs.Empty);
		}

		private static Dictionary<string, string> GetDictionary(AppLanguage language)
		{
			return language switch
			{
				AppLanguage.Chinese => Chinese,
				AppLanguage.Norwegian => Norwegian,
				_ => English
			};
		}

		private static AppLanguage Parse(string value)
		{
			return value switch
			{
				"zh" => AppLanguage.Chinese,
				"nb" => AppLanguage.Norwegian,
				_ => AppLanguage.English
			};
		}

		private static string ToSetting(AppLanguage language)
		{
			return language switch
			{
				AppLanguage.Chinese => "zh",
				AppLanguage.Norwegian => "nb",
				_ => "en"
			};
		}
	}
}
