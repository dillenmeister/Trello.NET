using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TrelloNet.Internal
{
	internal class ActionConverter : JsonCreationConverter<Action>
	{
		private static readonly Dictionary<string, Func<Action>> TypeMap = new Dictionary<string, Func<Action>>
		{
			{ "removeMemberFromCard", () => new RemoveMemberFromCardAction() },
			{ "addMemberToCard", () => new AddMemberToCardAction() },
			{ "addMemberToBoard", () => new AddMemberToBoardAction() },
			{ "removeMemberFromBoard", () => new RemoveMemberFromBoardAction() },
			{ "commentCard", () => new CommentCardAction() },
			{ "addAttachmentToCard", () => new AddAttachmentToCardAction() },
			{ "deleteAttachmentFromCard", () => new DeleteAttachmentFromCardAction() },
			{ "createBoard", () => new CreateBoardAction() },
			{ "createCard", () => new CreateCardAction() },
			{ "addToOrganizationBoard", () => new AddToOrganizationBoardAction() },
			{ "addChecklistToCard", () => new AddChecklistToCardAction() },
			{ "removeChecklistFromCard", () => new RemoveChecklistFromCardAction() },
			{ "updateCheckItemStateOnCard", () => new UpdateCheckItemStateOnCardAction() },
			{ "createList", () => new CreateListAction() },
			{ "createOrganization", () => new CreateOrganizationAction() },
			{ "updateOrganization", () => new UpdateOrganizationAction() }
		};

		protected override Action Create(Type objectType, JObject jObject)
		{
			Func<Action> specificAction;
			if (TypeMap.TryGetValue(ParseType(jObject), out specificAction))
				return specificAction();

			return new Action();
		}

		private static string ParseType(JObject jObject)
		{
			return jObject["type"].ToObject<string>();
		}
	}
}