using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TrelloNet.Internal
{
    internal class NotificationConverter : JsonCreationConverter<Notification>
	{
		private static readonly Dictionary<string, Func<Notification>> TypeMap = new Dictionary<string, Func<Notification>>
		{
			{ "addedToCard", () => new AddedToCardNotification() },
			{ "invitedToBoard", () => new InvitedToBoardNotification() },
			{ "addedToBoard", () => new AddedToBoardNotification() },
			{ "addAdminToBoard", () => new AddAdminToBoardNotification() },
			{ "addAdminToOrganization", () => new AddAdminToOrganization() },
			{ "changeCard", () => new ChangeCardNotification() },
			{ "removedFromCard", () => new RemovedFromCardNotification() },
			{ "removedFromBoard", () => new RemovedFromBoardNotification() },
			{ "closeBoard", () => new CloseBoardNotification() },
			{ "commentCard", () => new CommentCardNotification() },
			{ "invitedToOrganization", () => new InvitedToOrganizationNotification() },
			{ "removedFromOrganization", () => new RemovedFromOrganizationNotification() },
			{ "mentionedOnCard", () => new MentionedOnCardNotification() }
		};

		protected override Notification Create(Type objectType, JObject jObject)
		{
			Func<Notification> specificNotification;
			if (TypeMap.TryGetValue(ParseType(jObject), out specificNotification))
				return specificNotification();

			return new Notification();
		}

		private static string ParseType(JObject jObject)
		{
			return jObject["type"].ToObject<string>();
		}
	}
}