﻿using System;
using System.Text;

namespace iayos.ServiceStack.RollbarPlugin.AdaptedFromRollbar
{
	public class RollbarConfig : IRollbarConfig
	{

		internal RollbarConfig()
		{
			this.SetDefaults();
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="RollbarConfig"/> class.
		/// </summary>
		/// <param name="accessToken">The access token.</param>
		public RollbarConfig(string accessToken)
		{
			Assumption.AssertNotNullOrWhiteSpace(accessToken, nameof(accessToken));

			this.SetDefaults();
			this.AccessToken = accessToken;
		}

		private void SetDefaults()
		{
			// let's set some default values:
			this.Environment = "production";
			this.Enabled = true;
			this.MaxReportsPerMinute = 60;
			this.ReportingQueueDepth = 20;
			this.LogLevel = ErrorLevel.Debug;
			this.ScrubFields = new[]
			{
				"passwd",
				"password",
				"secret",
				"confirm_password",
				"password_confirmation",
			};
			this.EndPoint = "https://api.rollbar.com/api/1/";
			this.ProxyAddress = null;
			this.CheckIgnore = null;
			this.Transform = null;
			this.Truncate = null;
			this.Server = null;
			this.Person = null;
		}
		


		/// <summary>
		/// Gets the access token.
		/// </summary>
		/// <value>
		/// The access token.
		/// </value>
		public string AccessToken { get; set; }

		/// <summary>
		/// Gets or sets the end point.
		/// </summary>
		/// <value>
		/// The end point.
		/// </value>
		public string EndPoint { get; set; }

		/// <summary>
		/// Gets or sets the scrub fields.
		/// </summary>
		/// <value>
		/// The scrub fields.
		/// </value>
		public string[] ScrubFields { get; set; }

		/// <summary>
		/// Gets or sets the log level.
		/// </summary>
		/// <value>
		/// The log level.
		/// </value>
		public ErrorLevel? LogLevel { get; set; }

		/// <summary>
		/// Gets or sets the enabled.
		/// </summary>
		/// <value>
		/// The enabled.
		/// </value>
		public bool? Enabled { get; set; }

		/// <summary>
		/// Gets or sets the environment.
		/// </summary>
		/// <value>
		/// The environment.
		/// </value>
		public string Environment { get; set; }

		/// <summary>
		/// Gets or sets the check ignore.
		/// </summary>
		/// <value>
		/// The check ignore.
		/// </value>
		public Func<Payload, bool> CheckIgnore { get; set; }

		/// <summary>
		/// Gets or sets the transform.
		/// </summary>
		/// <value>
		/// The transform.
		/// </value>
		public Action<Payload> Transform { get; set; }

		/// <summary>
		/// Gets or sets the truncate.
		/// </summary>
		/// <value>
		/// The truncate.
		/// </value>
		public Action<Payload> Truncate { get; set; }

		/// <summary>
		/// Gets or sets the server.
		/// </summary>
		/// <value>
		/// The server.
		/// </value>
		public Server Server { get; set; }

		/// <summary>
		/// Gets or sets the person.
		/// </summary>
		/// <value>
		/// The person.
		/// </value>
		public Person Person { get; set; }

		/// <summary>
		/// Gets or sets the proxy address.
		/// </summary>
		/// <value>
		/// The proxy address.
		/// </value>
		public string ProxyAddress { get; set; }

		/// <summary>
		/// Gets or sets the maximum reports per minute.
		/// </summary>
		/// <value>
		/// The maximum reports per minute.
		/// </value>
		public int MaxReportsPerMinute { get; set; }

		/// <summary>
		/// Gets or sets the reporting queue depth.
		/// </summary>
		/// <value>
		/// The reporting queue depth.
		/// </value>
		public int ReportingQueueDepth { get; set; }

		/// <summary>
		/// Traces as a string.
		/// </summary>
		/// <param name="indent">The indent.</param>
		/// <returns>
		/// String rendering of this instance.
		/// </returns>
		public string TraceAsString(string indent = "")
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(indent + this.GetType().Name + ":");
			sb.AppendLine(indent + "  AccessToken: " + this.AccessToken);
			sb.AppendLine(indent + "  EndPoint: " + this.EndPoint);
			sb.AppendLine(indent + "  ScrubFields: " + this.ScrubFields);
			sb.AppendLine(indent + "  Enabled: " + this.Enabled);
			sb.AppendLine(indent + "  Environment: " + this.Environment);
			sb.AppendLine(indent + "  Server: " + this.Server);
			sb.AppendLine(indent + "  Person: " + this.Person);
			sb.AppendLine(indent + "  ProxyAddress: " + this.ProxyAddress);
			sb.AppendLine(indent + "  MaxReportsPerMinute: " + this.MaxReportsPerMinute);
			//sb.AppendLine(indent + this.Result.Trace(indent + "  "));
			return sb.ToString();
		}
	}
}