﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExpenses.Web.Resources
{
    using System;

	/// <summary>
	///   A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	// This class was auto-generated by the StronglyTypedResourceBuilder
	// class via a tool like ResGen or Visual Studio.
	// To add or remove a member, edit your .ResX file then rerun ResGen
	// with the /str option, or rebuild your VS project.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	public class Resource
	{

		private static global::System.Resources.ResourceManager resourceMan;

		private static global::System.Globalization.CultureInfo resourceCulture;

		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Resource()
		{
		}

		/// <summary>
		///   Returns the cached ResourceManager instance used by this class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Taxi.Web.Resources.Resource", typeof(Resource).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}

		/// <summary>
		///   Overrides the current thread's CurrentUICulture property for all
		///   resource lookups using this strongly typed resource class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Globalization.CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to The password was changed successfully..
		/// </summary>
		public static string ChangePasswordSuccess
		{
			get
			{
				return ResourceManager.GetString("ChangePasswordSuccess", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Confirm.
		/// </summary>
		public static string Confirm
		{
			get
			{
				return ResourceManager.GetString("Confirm", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Confirm Email.
		/// </summary>
		public static string ConfirmEmail
		{
			get
			{
				return ResourceManager.GetString("ConfirmEmail", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to To allow the user, please click on this link:.
		/// </summary>
		public static string EmailConfirmationBody
		{
			get
			{
				return ResourceManager.GetString("EmailConfirmationBody", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to A Confirmation email was sent. Please confirm your account and log into the App..
		/// </summary>
		public static string EmailConfirmationSent
		{
			get
			{
				return ResourceManager.GetString("EmailConfirmationSent", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Email confirmation.
		/// </summary>
		public static string EmailConfirmationSubject
		{
			get
			{
				return ResourceManager.GetString("EmailConfirmationSubject", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to To reset the password click in this link:.
		/// </summary>
		public static string RecoverPasswordBody
		{
			get
			{
				return ResourceManager.GetString("RecoverPasswordBody", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to An email with instructions to change the password was sent..
		/// </summary>
		public static string RecoverPasswordEmailSent
		{
			get
			{
				return ResourceManager.GetString("RecoverPasswordEmailSent", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Recover Password.
		/// </summary>
		public static string RecoverPasswordSubject
		{
			get
			{
				return ResourceManager.GetString("RecoverPasswordSubject", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Reject.
		/// </summary>
		public static string Reject
		{
			get
			{
				return ResourceManager.GetString("Reject", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to has requested that you be a member of their user group in the TAXI application..
		/// </summary>
		public static string RequestJoinGroupBody
		{
			get
			{
				return ResourceManager.GetString("RequestJoinGroupBody", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to An email has been sent to the user with your request, we hope to respond soon!.
		/// </summary>
		public static string RequestJoinGroupEmailSent
		{
			get
			{
				return ResourceManager.GetString("RequestJoinGroupEmailSent", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to Request to join a group.
		/// </summary>
		public static string RequestJoinGroupSubject
		{
			get
			{
				return ResourceManager.GetString("RequestJoinGroupSubject", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to The user.
		/// </summary>
		public static string TheUser
		{
			get
			{
				return ResourceManager.GetString("TheUser", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to The user already belongs to your group..
		/// </summary>
		public static string UserAlreadyBelogToGroup
		{
			get
			{
				return ResourceManager.GetString("UserAlreadyBelogToGroup", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to User already exists..
		/// </summary>
		public static string UserAlreadyExists
		{
			get
			{
				return ResourceManager.GetString("UserAlreadyExists", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to User doesn&apos;t exists..
		/// </summary>
		public static string UserNotFoundError
		{
			get
			{
				return ResourceManager.GetString("UserNotFoundError", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to If you wish to accept, click here: .
		/// </summary>
		public static string WishToAccept
		{
			get
			{
				return ResourceManager.GetString("WishToAccept", resourceCulture);
			}
		}

		/// <summary>
		///   Looks up a localized string similar to If you wish to reject, click here: .
		/// </summary>
		public static string WishToReject
		{
			get
			{
				return ResourceManager.GetString("WishToReject", resourceCulture);
			}
		}
	}
}