namespace BBSFW.Properties
{
	internal sealed partial class Settings
	{
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("purple")]
		public string AccentTheme
		{
			get
			{
				return ((string)(this["AccentTheme"]));
			}
			set
			{
				this["AccentTheme"] = value;
			}
		}
	}
}
